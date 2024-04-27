using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien;

namespace QuanLySinhVien.Student
{
    public partial class NhanTb : Form
    {
        FirestoreDb db = FirestoreDb.Create("ltmcb-7d1a6");

        public NhanTb()
        {
            InitializeComponent();
        }

        private async void NhanTb_Load(object sender, EventArgs e)
        {
            string maso = DangNhap.maso;
            await DisplayNotifications(maso);
        }

        private async Task DisplayNotifications(string maso)
        {
            try
            {
                if (db == null)
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.");
                    return;
                }

                CollectionReference studentRef = db.Collection("InfoStudent");
                DocumentReference docRef = studentRef.Document(maso);

                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                List<string> notifications = snapshot.GetValue<List<string>>("Messages");

                if (notifications != null && notifications.Count > 0)
                {
                    // Sắp xếp danh sách thông báo theo thứ tự mới nhất trước
                    notifications = notifications.OrderByDescending(msg => msg).ToList();

                    // Hiển thị danh sách thông báo trong ListBox
                    listBox1.DataSource = notifications;
                }
                else
                {
                    MessageBox.Show("Không có thông báo nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
