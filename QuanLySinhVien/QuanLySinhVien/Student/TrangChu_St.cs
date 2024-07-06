using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Google.Cloud.Storage.V1;
using QuanLySinhVien.Chat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace QuanLySinhVien.Student
{
    public partial class TrangChu_St : Form
    {
        private List<Guna.UI2.WinForms.Guna2Button> buttons;
        private Form activeForm = null;
        private Color activeButtonColor = Color.Gray;
        private Color defaultButtonColor = Color.White;
        private string StudentId { get; set; } // Thêm thuộc tính StudentId

        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;

        FirestoreDb firestoreDb;
        StorageClient storageClient;

        public TrangChu_St(string studentId)
        {
            InitializeComponent();
            connectToServer(); // kết nối tới server khi load form 
            string projectId = "ltmcb-7d1a6";
            firestoreDb = FirestoreDb.Create(projectId);
            StudentId = studentId; // Gán giá trị studentId cho thuộc tính
            storageClient = StorageClient.Create();
            InitializeButtons();
            
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
            // Thêm các Button vào danh sách
            buttons = new List<Guna.UI2.WinForms.Guna2Button> { btn_Shedule ,btXemdiem, btThongbao, btDeadline, btChat, btUser};

            //Gọi chatbox
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
            //chatBox1 chatbox = new chatBox1(username, DangNhap.maso, tcpClient, reader, writer);


            // Gán sự kiện Click cho mỗi Button
            foreach (var button in buttons)
            {
                button.Click += Button_Click;
            }

            // Gán form tương ứng cho mỗi nút bằng cách sử dụng thuộc tính Tag
            btXemdiem.Tag = new xemDiem();
            btThongbao.Tag = new NhanTb();
            btDeadline.Tag = new Deadline(StudentId); // Truyền studentId vào đây
            btn_Shedule.Tag = new Tkb();
            btUser.Tag = new User_St();
            btChat.Tag= new chatBox1(username, DangNhap.maso, tcpClient, reader, writer);

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;

            // Đặt tất cả các Button về màu mặc định
            foreach (var button in buttons)
            {
                button.BackColor = defaultButtonColor;
            }

            // Đặt màu xám cho Button được nhấn
            clickedButton.BackColor = activeButtonColor;

            // Mở Form tương ứng với Button được nhấn
            if (clickedButton == btDeadline)
            {
                openChildForm(new Deadline(StudentId));
            }
            else if (clickedButton.Tag is Form)
            {
                openChildForm(clickedButton.Tag as Form);
            }
        }

        private async void openChildForm(Form childForm)
        {
            // Thêm các Button vào danh sách
            buttons = new List<Guna.UI2.WinForms.Guna2Button> { btn_Shedule, btXemdiem, btThongbao, btDeadline, btChat, btUser };

            //Gọi chatbox
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

            if (activeForm != null && !activeForm.IsDisposed)
            {
                activeForm.Hide(); // Ẩn form thay vì đóng
            }

            activeForm = childForm;

            if (childForm.IsDisposed)
            {
                // Nếu form đã bị disposed, khởi tạo lại form mới
                if (childForm is xemDiem)
                    activeForm = new xemDiem();
                else if (childForm is NhanTb)
                    activeForm = new NhanTb();
                else if (childForm is Deadline)
                    activeForm = new Deadline(StudentId);
                else if (childForm is Tkb)
                    activeForm = new Tkb();
                else if (childForm is User_St)
                    activeForm = new User_St();
                else if (childForm is chatBox1)
                    activeForm = new chatBox1(username, DangNhap.maso, tcpClient, reader, writer);
            }

            childForm = activeForm; // Gán lại form mới nếu cần
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void TrangChu_St_Load(object sender, EventArgs e)
        {

        }
      

     
        //mở form chat
     

        //khi tắt ứng dụng thì các file lưu tin nhắn tạm cũng bị xóa đi 
        private void TrangChu_St_FormClosed(object sender, FormClosedEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
