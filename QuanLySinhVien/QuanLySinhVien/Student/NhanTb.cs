﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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

                itemText = itemText.Replace("\r", " ").Replace("\n", " ");
                itemText = itemText.Substring(0,30);               

                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
                }
            }
        }
    }
}
