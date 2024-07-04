using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;
using QuanLySinhVien.Chat;
using QuanLySinhVien.Student;
using QuanLySinhVien.Teacher;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class TrangChu_Tea : Form
    {
        private List<Button> buttons;
        private Form activeForm = null;
        private Color activeButtonColor = Color.Gray;
        private Color defaultButtonColor = Color.White;

        private Dictionary<Button, Form> buttonFormMapping;

        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;

        FirestoreDb firestoreDb;
        StorageClient storageClient;

        public TrangChu_Tea()
        {
            string projectId = "ltmcb-7d1a6";
            firestoreDb = FirestoreDb.Create(projectId);
            storageClient = StorageClient.Create();
            InitializeComponent();
            connectToServer(); // kết nối tới server khi load form 
            InitializeButtons();
            InitializeButtonFormMapping();
        }
        //hàm kết nối tới server
        private void connectToServer()
        {
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            }
            catch
            {
                MessageBox.Show("Máy chủ không hoạt động!");
                return;
            }
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());
            //gửi id tới server để server lưu làm key bên server
            writer.WriteLine(DangNhap.maso);
            writer.Flush();
        }
        private void InitializeButtons()
        {
            // Thêm các Button vào danh sách
            buttons = new List<Button> { btNhapDiem, btThongKe, btThongBao, btDsLop, bt_User, btTask, btChat };

            // Gán sự kiện Click cho mỗi Button
            foreach (var button in buttons)
            {
                button.Click += Button_Click;
            }
        }

        private void InitializeButtonFormMapping()
        {
            buttonFormMapping = new Dictionary<Button, Form>
            {
                { btNhapDiem, new QuanLyDiem() },
                { btThongKe, new ThongKe() },
                { btThongBao, new ThongBao() },
                { btDsLop, new QuanLyLop() },
                { bt_User, new User_Tea() },
                { btTask, new giaoTask() },
                { btChat, new chatBox() },
            };
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // Đặt tất cả các Button về màu mặc định
            foreach (var button in buttons)
            {
                button.BackColor = defaultButtonColor;
            }

            // Đặt màu xám cho Button được nhấn
            clickedButton.BackColor = activeButtonColor;


            // Gán form tương ứng cho mỗi nút bằng cách sử dụng thuộc tính Tag
            btNhapDiem.Tag = new QuanLyDiem();
            btThongKe.Tag = new ThongKe();
            btThongBao.Tag = new ThongBao();
            btDsLop.Tag = new QuanLyLop();
            bt_User.Tag = new User_Tea();
            btTask.Tag = new giaoTask();
            //btChat.Tag = new chatBox();

            // Mở Form tương ứng với Button được nhấn
            if (clickedButton.Tag is Form)
            {
                openChildForm(clickedButton.Tag as Form);
            }
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private async void bt_dangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap form = new DangNhap();
            form.ShowDialog();
        }

        //mở form chat
        private async void btChat_Click(object sender, EventArgs e)
        {
            string username = "";
            DocumentReference docRef = firestoreDb.Collection("UserData").Document(DangNhap.maso);
            DocumentSnapshot docSnapshot = await docRef.GetSnapshotAsync();
            // Kiểm tra xem tài liệu có tồn tại hay không
            if (docSnapshot.Exists)
            {
                // Lấy dữ liệu từ tài liệu
                Dictionary<string, object> studentData = docSnapshot.ToDictionary();
                username = studentData.ContainsKey("Name") ? studentData["Name"].ToString() : "";
            }
            // truyền các tham số như tên, id, tcpclient, streamreader, streamwriter
            chatBox1 chatBox1 = new chatBox1(username, DangNhap.maso, tcpClient, reader, writer);
            chatBox1.Visible = true;
        }
        //khi tắt ứng dụng thì các file lưu tin nhắn tạm cũng bị xóa đi 
        private void TrangChu_Tea_FormClosed(object sender, FormClosedEventArgs e)
        {
            string foldePpath = "Temp_Mess_History";
            if (Directory.Exists(foldePpath))
            {
                string[] fileNames = Directory.GetFiles(foldePpath);
                foreach (string fileName in fileNames)
                {
                    if (File.Exists(fileName))
                    {
                        try
                        {
                            // Xóa file
                            File.Delete(fileName);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
        }
    }
}
