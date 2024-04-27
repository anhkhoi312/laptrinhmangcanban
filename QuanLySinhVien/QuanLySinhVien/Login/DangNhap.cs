using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using QuanLySinhVien.Classes;
using QuanLySinhVien.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
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
    }
}
