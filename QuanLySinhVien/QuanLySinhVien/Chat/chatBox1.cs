using Bunifu.UI.WinForms;
using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLySinhVien.Chat
{
    public partial class chatBox1 : Form
    {
        public chatBox1(string username, string id,TcpClient tcpClient, StreamReader reader, StreamWriter writer)
        {
            isRunning = true;
            this.username = username;
            this.id = id;
            this.reader = reader;
            this.writer = writer;
            InitializeComponent();
            Thread receivedThread = new Thread(received);
            receivedThread.Start();
            receivedThread.IsBackground = true;
        }
        //lưu username
        private string username;
        //lưu id
        private string id;
        //đọc tin nhắn từ server gửi vể
        private StreamReader reader;
        //gửi tin nhắn từ client đến server
        private StreamWriter writer;
        private bool isRunning = false;
        //lấy thông tin từ firebase
        private FirestoreDb db = FirestoreDb.Create("ltmcb-7d1a6");
        private static string bucketName = "ltmcb-7d1a6.appspot.com";
        private FirebaseClient firebaseClient = new FirebaseClient("https://ltmcb-7d1a6-default-rtdb.firebaseio.com/");
        //lưu ds 1 button tương ứng với 1 flowpanel
        private Dictionary<System.Windows.Forms.Button, FlowLayoutPanel> id_boxchat;
        //ds các button mở trang chat
        private List<System.Windows.Forms.Button> buttons;
        
        //tạo 1 flowpanel để show tin nhắn 
        private FlowLayoutPanel createFlowlayoutPanel()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.AllowDrop = true;
            flowLayoutPanel.BackColor = Color.White;
            flowLayoutPanel.Dock = DockStyle.Fill;
            panel2.Controls.Add(flowLayoutPanel);
            flowLayoutPanel.Visible = false;
            return flowLayoutPanel;
        }
        //class message để gửi và nhận tin nhắn
        class message
        {
            public string sender { get; set; }
            public string id_sender { get; set; }
            public string receiver { get; set; }
            public string id_receiver { get; set; }
            public string data { get; set; }
        }
        //hàm này dùng để show 1 control từ luồng khác lên luồng UI. Có thể sử dụng invoke
        private void AddControlToForm(UserControl control, System.Windows.Forms.Button index)
        {
            FlowLayoutPanel selectedFlowlayoutPanel = id_boxchat[index];
            if (selectedFlowlayoutPanel.InvokeRequired)
            {
                selectedFlowlayoutPanel.Invoke(new MethodInvoker(delegate { AddControlToForm(control, index); }));
            }
            else
            {
                selectedFlowlayoutPanel.Controls.Add(control);
            }
        }
        //Hàm nhận thông tin từ server được chạy từ 1 luồng riêng được khởi tạo khi load form
        private void received()
        {
            try
            {
                while (isRunning)
                {
                    //đọc tin nhắn từ server gửi về
                    string messFromServer = reader.ReadLine();
                    //lấy tín hiệu mà server gửi
                    string message = messFromServer.Substring(messFromServer.IndexOf('|') + 1);
                    //lấy nội dung mà server gửi
                    messFromServer = messFromServer.Substring(0, messFromServer.IndexOf('|'));
                    // nếu tín hiệu là mesage
                    if (messFromServer == "Message")
                    {
                        //giải mã nội 
                        message newMessage = JsonConvert.DeserializeObject<message>(message);
                        //duyệt qua từng button để tìm ra flowpanel nào để load tin nhắn lên
                        foreach (var item in id_boxchat)
                        {
                            //khi tìm thấy button 
                            if (newMessage.id_sender == item.Key.Text)
                            {
                                Invoke(new Action(() =>
                                {
                                    //tạo 1 usercontrol hoặc có thể tạo 1 label 
                                    userControlMessage reMess = new userControlMessage(username);
                                    //vì bên trong usercontrol nay có 1 label nên cần sửa label đó để hiển thị nội dung
                                    reMess.setLabel(newMessage.data, newMessage.sender);
                                    //gọi hàm hiển thị lên flowpanel
                                    AddControlToForm(reMess, item.Key);
                                    
                                    //item.Value.Controls.Add(reMess); => có thể load lên theo cách này
                                    string ghiFile = reMess.getString(newMessage.sender);
                                    //lấy nội dung của label bên trong usercontrol 
                                    //nếu không rỗng
                                    if (ghiFile.Trim() != "")
                                    {
                                        //tạo 1 tên file để lưu tạm tin nhắn cho 1 phiên làm việc. Khi tắt app thì các file tạm này sẽ mất theo
                                        string fileName = $"history-{newMessage.id_sender}.txt";
                                        //lấy đường dẫn đến file
                                        string filepath = Path.Combine("Temp_Mess_History\\", fileName);
                                        //ghi từng dòng xuống file
                                        StreamWriter wri = new StreamWriter(filepath, true);
                                        wri.AutoFlush = true;
                                        wri.WriteLine($"{ghiFile}");
                                        //đóng ghi file để không xảy ra lỗi
                                        wri.Close();
                                    }
                                }));
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        //Hàm hiển thị panel với việc click vào button tương ứng 
        private void click_show_panel(object sender, EventArgs e)
        {
            //bắt lấy button nào được click
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
            //nếu tồn tạo trong ds button_panel
            if (id_boxchat.ContainsKey(clickedButton))
            {
                //duyệt từng phần tử
                foreach (var item in id_boxchat)
                {
                    //nếu đúng thì hiển thị duy nhất panel này các panel khác thì ẩn hết
                    if (item.Key == clickedButton)
                    {
                        item.Value.Visible = true;
                        panel4.Visible = true;
                        label1.Text = clickedButton.Text;
                        textBox1.Clear();
                    }
                    //ẩn các panel còn lại
                    else
                    {
                        item.Value.Visible = false;
                    }
                }
            }
        }
        //lấy thông tin vào tạo các cặp button_panel khi load form
        private async void chatBox1_Load(object sender, EventArgs e)
        {
            try
            {
                //truy cập đến Userdata để lấy các id 
                CollectionReference userRef = db.Collection("UserData");
                QuerySnapshot snapshot = await userRef.GetSnapshotAsync();
                id_boxchat = new Dictionary<System.Windows.Forms.Button, FlowLayoutPanel>();
                buttons = new List<System.Windows.Forms.Button>();
                if (snapshot != null && snapshot.Documents.Count > 0)
                {
                    foreach (DocumentSnapshot doc in snapshot.Documents)
                    {
                        //duyệt các id
                        //bỏ qua nếu đó là id của bản thân
                        if (doc.Id != this.id)
                        {
                            System.Windows.Forms.Button button = createButton(doc.Id); //tạo button 
                            buttons.Add(button);//add vào ds
                            button.Click += click_show_panel; //add sự kiện click
                            flowLayoutPanel1.Controls.Add(button); //add button vừa tạo và panel bên trái của form
                            FlowLayoutPanel flowLayoutPanel = createFlowlayoutPanel();//tạo 1 flowpanel 
                            panel3.Controls.Add(flowLayoutPanel);// add panel
                            id_boxchat.Add(button, flowLayoutPanel);//add 1 cặp button_panel
                        }
                    }
                    //load tin nhắn cũ từ file
                    foreach (var item in id_boxchat)
                    { 
                        string fileName = "Temp_Mess_History\\history-" + item.Key.Text + ".txt"; //đường dẫn
                        if (File.Exists(fileName))
                        {
                            StreamReader r = new StreamReader(fileName);
                            string data;
                            while ((data = r.ReadLine()) != null) // đọc đến khi hết file
                            {
                                if (data.Contains(this.username)) // trong data có tồn tại tên của bản thân thì add nó vào label hiển thị bên phải
                                {
                                    userControlMessage reMess = new userControlMessage(username);
                                    reMess.setLabel(data.Substring(0, data.IndexOf(':') - 1), data.Substring(data.IndexOf(':') + 1));
                                    item.Value.Controls.Add(reMess);
                                }
                                else // nếu không tồn tại thì hiển thị bên trái
                                {
                                    userControlMessage reMess = new userControlMessage(username);
                                    reMess.setLabel(data.Substring(data.IndexOf(':') - 1), data.Substring(0, data.IndexOf(':') + 1));
                                    item.Value.Controls.Add(reMess);
                                }
                            }
                            r.Close(); //đọc xong thì đóng không thì lỗi :)))
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có tài khoản để chat!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải danh sách người dùng: " + ex.Message);
            }
        }
        //hàm tạo 1 butotn 
        private System.Windows.Forms.Button createButton(string id)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = id;
            button.Size = new Size(190, 50);
            return button;
        }
        //nút gửi tin nhắn
        private void btn_send_Click(object sender, EventArgs e)
        {
            //tạo 1 đối tượng mess để gửi đi
            message newMessage = new message
            {
                sender = this.username,
                data = textBox1.Text,
                receiver = label1.Text,
                id_sender = this.id,
                id_receiver = label1.Text
            };
            // chuyển nó thành chuỗi string để gửi đi vì streamreader và streamwriter thao tác với string
            string data = JsonConvert.SerializeObject(newMessage);
            writer.WriteLine("Message"); //gửi tín hiệu để server biết có 1 tin nhắn sắp đến
            writer.WriteLine(data); //gửi tin nhắn 
            writer.Flush();// ghi xuống đường truyền
            foreach (var item in id_boxchat) // tìm id tương ứng để hiển thì lên panel tương ứng của chat
            {
                if (newMessage.id_receiver == item.Key.Text)
                {
                    userControlMessage reMess = new userControlMessage(username);
                    reMess.setLabel(newMessage.data, newMessage.sender);
                    item.Value.Controls.Add(reMess);
                    // ghi xuống file để lưu lại tin nhắn 
                    string ghiFile = reMess.getString(newMessage.sender);
                    {
                        string fileName = $"history-{newMessage.id_receiver}.txt";
                        string filepath = Path.Combine("Temp_Mess_History\\", fileName);
                        StreamWriter wri = new StreamWriter(filepath, true);
                        wri.AutoFlush = true;
                        wri.WriteLine($"{ghiFile}");
                        wri.Close();
                    }
                    textBox1.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
