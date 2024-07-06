using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;
using Guna.UI2.WinForms;
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
        private List<Guna2Button> buttons;
        private Form activeForm = null;
        private Color activeButtonColor = Color.Gray;
        private Color defaultButtonColor = Color.White;

        private Dictionary<Guna2Button, Form> buttonFormMapping;

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
        private async void InitializeButtons()
        {
            // Hàm gọi chatbox
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

            // Thêm các Button vào danh sách
            buttons = new List<Guna2Button> { btNhapDiem, btThongKe, btThongBao, btDsLop, bt_User, btTask, bt_dangXuat, btchat };

            // Gán sự kiện Click cho mỗi Button
            foreach (var button in buttons)
            {
                button.Click += Button_Click;
            }

            btNhapDiem.Tag = new QuanLyDiem();
            btThongKe.Tag = new ThongKe();
            btThongBao.Tag = new ThongBao();
            btDsLop.Tag = new QuanLyLop();
            bt_User.Tag = new User_Tea();
            btTask.Tag = new giaoTask();
            btchat.Tag = new chatBox1(username, DangNhap.maso, tcpClient, reader, writer);

        }

        private void InitializeButtonFormMapping()
        {
            /*buttonFormMapping = new Dictionary<Guna2Button, Form>
            {
                { btNhapDiem, new QuanLyDiem() },
                { btThongKe, new ThongKe() },
                { btThongBao, new ThongBao() },
                { btDsLop, new QuanLyLop() },
                { bt_User, new User_Tea() },
                { btTask, new giaoTask() },
            };*/
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;

            // Đặt tất cả các Button về màu mặc định
            foreach (var button in buttons)
            {
                button.BackColor = defaultButtonColor;
            }

            // Đặt màu xám cho Button được nhấn
            clickedButton.BackColor = activeButtonColor;


            /*// Gán form tương ứng cho mỗi nút bằng cách sử dụng thuộc tính Tag
            btNhapDiem.Tag = new QuanLyDiem();
            btThongKe.Tag = new ThongKe();
            btThongBao.Tag = new ThongBao();
            btDsLop.Tag = new QuanLyLop();
            bt_User.Tag = new User_Tea();
            btTask.Tag = new giaoTask();
            //button1.Tag = new chatBox();*/

            // Mở Form tương ứng với Button được nhấn
            if (clickedButton.Tag is Form)
            {
                openChildForm(clickedButton.Tag as Form);
            }
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null && !activeForm.IsDisposed)
            {
                activeForm.Hide();
            }

            if (childForm.IsDisposed)
            {
                if (childForm is QuanLyDiem)
                    activeForm = new QuanLyDiem();
                else if (childForm is ThongKe)
                    activeForm = new ThongKe();
                else if (childForm is ThongBao)
                    activeForm = new ThongBao();
                else if (childForm is QuanLyLop)
                    activeForm = new QuanLyLop();
                else if (childForm is User_Tea)
                    activeForm = new User_Tea();
                else if (childForm is giaoTask)
                    activeForm = new giaoTask();
                else if (childForm is chatBox1)
                {
                    string username = "";
                    DocumentReference docRef = firestoreDb.Collection("UserData").Document(DangNhap.maso);
                    DocumentSnapshot docSnapshot = docRef.GetSnapshotAsync().Result;

                    if (docSnapshot.Exists)
                    {
                        Dictionary<string, object> studentData = docSnapshot.ToDictionary();
                        username = studentData.ContainsKey("Name") ? studentData["Name"].ToString() : "";
                    }

                    activeForm = new chatBox1(username, DangNhap.maso, tcpClient, reader, writer);
                }
            }
            else
            {
                activeForm = childForm;
            }

            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(activeForm);
            panel1.Tag = activeForm;
            activeForm.BringToFront();
            activeForm.Show();
        }

        private void TrangChu_Tea_Load(object sender, EventArgs e)
        {
        }

       
        //mở form chat
      
        //khi tắt ứng dụng thì các file lưu tin nhắn tạm cũng bị xóa đi 
        private void TrangChu_Tea_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_dangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap form = new DangNhap();
            form.ShowDialog();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
