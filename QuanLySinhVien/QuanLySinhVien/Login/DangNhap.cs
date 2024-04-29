using Google.Cloud.Firestore;
using QuanLySinhVien.Classes;
using QuanLySinhVien.Student;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        public static string maso {  get; set; }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string username = UserBox.Text.Trim();
            maso = username;
            string password = PassBox.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                errorLabel.Visible = true; // Hiển thị thông báo
                return; // Dừng lại ở đây để không thực hiện các thao tác tiếp theo
            }
            
            var db = FirestoreHelper.database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
            if (data != null )
            {
                if(password==data.Password)
                {
                    if (data.Type == "gv")
                    {
                        
                        TrangChu_Tea trangChu = new TrangChu_Tea();
                        trangChu.ShowDialog();
                    }
                    else if (data.Type == "st")
                    {
                       
                        TrangChu_St trangChu = new TrangChu_St();
                        trangChu.ShowDialog();
                    }
                    // Đóng cửa sổ hiện tại
                    this.Close();
                } 
                else
                {
                    MessageBox.Show("Kiểm tra lại tên người dùng hoặc mật khẩu");
                }
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            if(showpass.Checked == true)
            {
                PassBox.UseSystemPasswordChar = false;
            } else
            {
                PassBox.UseSystemPasswordChar = true;
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
