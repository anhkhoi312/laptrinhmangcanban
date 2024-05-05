using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Storage.V1;
using System.IO;

namespace QuanLySinhVien.Student
{
    public partial class User_St : Form
    {
        FirestoreDb firestoreDb;
        StorageClient storageClient;

        public User_St()
        {
            InitializeComponent();
            string projectId = "ltmcb-7d1a6";
            firestoreDb = FirestoreDb.Create(projectId);
            storageClient = StorageClient.Create();
        }



        private async void User_St_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin của sinh viên từ Firestore dựa trên MSSV đã đăng nhập
                DocumentReference docRef = firestoreDb.Collection("InfoStudent").Document(DangNhap.maso);
                DocumentSnapshot docSnapshot = await docRef.GetSnapshotAsync();

                // Kiểm tra xem tài liệu có tồn tại hay không
                if (docSnapshot.Exists)
                {
                    // Lấy dữ liệu từ tài liệu
                    Dictionary<string, object> studentData = docSnapshot.ToDictionary();

                    // Hiển thị thông tin của sinh viên vào các textbox
                    tb_name.Text = studentData.ContainsKey("Name") ? studentData["Name"].ToString() : "";
                    tb_address.Text = studentData.ContainsKey("Address") ? studentData["Address"].ToString() : "";
                    tb_class.Text = studentData.ContainsKey("Class") ? studentData["Class"].ToString() : "";
                    tb_dateofbirth.Text = studentData.ContainsKey("DateOfBirth") ? studentData["DateOfBirth"].ToString() : "";
                    tb_gmail.Text = studentData.ContainsKey("Mail") ? studentData["Mail"].ToString() : "";
                    tb_major.Text = studentData.ContainsKey("Major") ? studentData["Major"].ToString() : "";
                    tb_phonenum.Text = studentData.ContainsKey("PhoneNumber") ? studentData["PhoneNumber"].ToString() : "";

                    if (studentData.ContainsKey("Avatar_url"))
                    {
                        string avatarUrl = studentData["Avatar_url"].ToString();
                        await DisplayAvatar(avatarUrl);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin sinh viên.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin sinh viên: " + ex.Message);
            }
        }


        private async Task DisplayAvatar(string avatarUrl)
        {
            try
            {
                // Tách tên bucket và tên object từ URL
                string[] parts = avatarUrl.Replace("gs://", "").Split('/');
                string bucketName = parts[0];
                string objectName = string.Join("/", parts.Skip(1));

                // Tạo yêu cầu tải object từ bucket và object name
                Google.Apis.Storage.v1.Data.Object obj = await storageClient.GetObjectAsync(bucketName, objectName);

                // Tạo một MemoryStream để lưu trữ dữ liệu từ object tải xuống
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Tải dữ liệu của object vào memoryStream
                    await storageClient.DownloadObjectAsync(obj, memoryStream);

                    // Đặt con trỏ ở vị trí ban đầu của memoryStream để đọc dữ liệu
                    memoryStream.Position = 0;

                    // Tạo Bitmap từ dữ liệu trong memoryStream
                    Bitmap bmp = new Bitmap(memoryStream);

                    // Hiển thị Bitmap trên PictureBox
                    pictureBox1.Image = bmp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị ảnh đại diện: " + ex.Message);
            }
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap form = new DangNhap();
            form.ShowDialog();
        }

        private async void btn_taianh_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở dialog để chọn ảnh từ máy tính
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của file ảnh đã chọn
                    string filePath = openFileDialog.FileName;

                    // Tải ảnh lên Firebase Storage
                    string bucketName = "ltmcb-7d1a6.appspot.com";
                    string mssv = DangNhap.maso;
                    string objectName = $"{mssv}/avatar.png"; // Tên object để lưu trữ ảnh

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        await storageClient.UploadObjectAsync(bucketName, objectName, null, fileStream);
                    }

                    // Cập nhật URL avatar mới vào Firestore
                    string newAvatarUrl = $"gs://{bucketName}/{objectName}";
                    DocumentReference docRef = firestoreDb.Collection("InfoStudent").Document(DangNhap.maso);
                    await docRef.UpdateAsync("Avatar_url", newAvatarUrl);

                    // Hiển thị ảnh mới
                    await DisplayAvatar(newAvatarUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh lên: " + ex.Message);
            }
        }

        
    }
}
