using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.Chat
{
    public partial class chatBox : Form
    {

        private FirestoreDb db = FirestoreDb.Create("ltmcb-7d1a6");
        private static string bucketName = "ltmcb-7d1a6.appspot.com";
        private FirebaseClient firebaseClient = new FirebaseClient("https://ltmcb-7d1a6-default-rtdb.firebaseio.com/");
        private string maso = DangNhap.maso;
        private string chatId;

        public chatBox()
        {
            InitializeComponent();
        }

        private async Task LoadPreviousChats()
        {
            try
            {
                // Lấy danh sách các id đoạn trò chuyện từ nút "chats"
                var chatIds = await firebaseClient.Child("chats").OnceAsync<Dictionary<string, object>>();

                // Hiển thị danh sách chatId trong listBox1
                foreach (var chat in chatIds)
                {
                    string chatId = chat.Key;
                    var chatData = chat.Object as Dictionary<string, object>;

                    // Kiểm tra xem người dùng hiện tại đã tham gia vào đoạn trò chuyện này chưa
                    if (chatId.Contains(maso))
                    {
                        // Lấy id của đối tác trong đoạn trò chuyện
                        string[] participants = chatId.Split('_');
                        string partnerId = participants.First(participant => participant != maso);

                        // Thêm id của đối tác vào listBox1
                        listBox1.Items.Add(partnerId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải danh sách tin nhắn trước đó: " + ex.Message);
            }
        }


        private async void chatBox_Load(object sender, EventArgs e)
        {
            try
            {
                CollectionReference userRef = db.Collection("UserData");
                QuerySnapshot snapshot = await userRef.GetSnapshotAsync();

                if (snapshot != null && snapshot.Documents.Count > 0)
                {
                    foreach (DocumentSnapshot doc in snapshot.Documents)
                    {
                        comboBox1.Items.Add(doc.Id); // Thêm ID của mỗi document vào combobox
                    }
                }
                else
                {
                    MessageBox.Show("Không có tài khoản để chat!");
                }
                // Hiển thị danh sách người dùng đã nhắn tin trước đó vào listBox1
                await LoadPreviousChats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải danh sách người dùng: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedUserId = comboBox1.SelectedItem.ToString();    
            try
            {
                // Tải ảnh đại diện và tên lên
                LoadAvatarFromGcs(selectedUserId);
                // Lấy hoặc tạo chat ID khi người dùng chọn một người nhắn tin mới
                chatId = GetOrCreateChatId(selectedUserId);
                // Hiển thị tin nhắn giữa hai người
                LoadMessages(chatId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải ảnh đại diện: " + ex.Message);
            }
        }
    
        private void LoadAvatarFromGcs(string selectedUserId)
        {
            try
            {
                string avatarFilePath = $"{selectedUserId}/avatar.png";
                var storageClient = StorageClient.Create();
                using (var memoryStream = new MemoryStream())
                {
                    storageClient.DownloadObject(bucketName, avatarFilePath, memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    pictureBox1.Image = Image.FromStream(memoryStream);
                }
                DocumentReference docRef = db.Collection("UserData").Document(selectedUserId); // DangNhap.maso là giá trị của maso
                DocumentSnapshot snapshot = docRef.GetSnapshotAsync().Result; // Đợi cho việc lấy dữ liệu hoàn thành

                if (snapshot.Exists)
                {
                    string name = snapshot.GetValue<string>("Name");
                    // Hiển thị giá trị name vào Label1
                    label1.Text = name;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài liệu có id là " + DangNhap.maso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải ảnh đại diện từ GCS: " + ex.Message);
            }
        }

        private string GetOrCreateChatId(string selectedUserId)
        {
            // Tạo một chat ID dựa trên ID của hai người tham gia cuộc trò chuyện
            string[] userIds = { DangNhap.maso, selectedUserId };
            Array.Sort(userIds);
            string chatId = string.Join("_", userIds);

            return chatId;
        }

        private async void LoadMessages(string chatId)
        {
            try
            {
                richTextBox1.Clear();
                var messages = await firebaseClient.Child("chats").Child(chatId).Child("messages").OnceAsync<Message>();

                foreach (var message in messages)
                {
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(message.Object.Timestamp); // Tạo DateTimeOffset từ giá trị long
                    DateTime dateTime = dateTimeOffset.UtcDateTime.ToLocalTime(); // Chuyển đổi từ DateTimeOffset sang DateTime
                    richTextBox1.AppendText($"{dateTime.ToString("yyyy-MM-dd HH:mm:ss")} - {message.Object.SenderId}: {message.Object.Content}\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải tin nhắn: " + ex.Message);
            }
        }

        private async void buttonSend_Click_1(object sender, EventArgs e)
        {
            string receiverId = comboBox1.SelectedItem.ToString();
            string messageContent = textBoxMessage.Text;

            if (!string.IsNullOrEmpty(messageContent))
            {
                try
                {
                    // Gửi tin nhắn lên Firebase Realtime Database
                    var message = new Message { SenderId = maso, Content = messageContent, Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() };
                    await firebaseClient.Child("chats").Child(chatId).Child("messages").PostAsync(message);

                    // Hiển thị tin nhắn mới trên giao diện
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(message.Timestamp); // Tạo DateTimeOffset từ giá trị long
                    DateTime dateTime = dateTimeOffset.UtcDateTime.ToLocalTime(); // Chuyển đổi từ DateTimeOffset sang DateTime
                    richTextBox1.AppendText($"{dateTime.ToString("yyyy-MM-dd HH:mm:ss")} - You: {messageContent}\n");
                    textBoxMessage.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi gửi tin nhắn: " + ex.Message);
                }
            }
        }
        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi hàm gửi tin nhắn khi nhấn phím Enter
                buttonSend_Click_1(sender, e);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy id của người dùng được chọn từ listBox1
            string selectedUserId = listBox1.SelectedItem.ToString();
            //Tải ảnh đại diện và tên lên 
            LoadAvatarFromGcs(selectedUserId);
            // Lấy hoặc tạo chat ID khi người dùng chọn một người nhắn tin mới
            chatId = GetOrCreateChatId(selectedUserId);

            // Hiển thị tin nhắn giữa hai người
            LoadMessages(chatId);
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground(); // Vẽ nền
                e.DrawFocusRectangle(); // Vẽ khung chọn (nếu cần)

                // Vẽ dòng phân cách
                if (e.Index > 0)
                {
                    using (Pen pen = new Pen(Color.Black))
                    {
                        e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);
                    }
                }

                // Vẽ nội dung của mục
                string itemText = listBox1.GetItemText(listBox1.Items[e.Index]);
                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
                }
            }
        }

    }


    public class Message
    {
        public string SenderId { get; set; }
        public string Content { get; set; }
        public long Timestamp { get; set; }
    }
}
