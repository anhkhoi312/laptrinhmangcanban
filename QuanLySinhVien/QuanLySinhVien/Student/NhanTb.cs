using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    listBox1.DataSource = "Không thể kết nối với database";
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
                    listBox1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        private async Task DisplayNotificationDetail(string selectedNotification)
        {
            richTextBox1.Text = selectedNotification;
        }

        private async void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           

        }
        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedNotification = listBox1.SelectedItem.ToString();
                await DisplayNotificationDetail(selectedNotification);
            }
        }
    }
}
