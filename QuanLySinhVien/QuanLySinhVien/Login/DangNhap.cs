using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using QuanLySinhVien.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UserBox.Text.Trim();
            string password = PassBox.Text;
            var db = FirestoreHelper.database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
            if (data != null )
            {
                if(password==data.Password)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    // Tạo cửa sổ mới
                    Trangchu trangChu = new Trangchu();
                    trangChu.Show();
                    // Đóng cửa sổ hiện tại
                    this.Hide();
                } 
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi");
            }
        }

       
    }
}
