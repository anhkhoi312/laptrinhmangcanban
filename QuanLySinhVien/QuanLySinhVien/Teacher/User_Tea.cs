using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class User_Tea : Form
    {

        private FirestoreDb db = FirestoreDb.Create("ltmcb-7d1a6");
        StorageClient storageClient = StorageClient.Create();
        public User_Tea()
        {
            InitializeComponent();
        }

        private async void User_Tea_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin của sinh viên từ Firestore dựa trên MSSV đã đăng nhập
                DocumentReference docRef = db.Collection("InfoTeacher").Document(DangNhap.maso);
                DocumentSnapshot docSnapshot = await docRef.GetSnapshotAsync();

                // Kiểm tra xem tài liệu có tồn tại hay không
                if (docSnapshot.Exists)
                {
                    // Lấy dữ liệu từ tài liệu
                    Dictionary<string, object> data = docSnapshot.ToDictionary();

                    // Hiển thị thông tin của sinh viên vào các textbox
                    tb_name.Text = data.ContainsKey("Name") ? data["Name"].ToString() : "";
                    tb_address.Text = data.ContainsKey("Address") ? data["Address"].ToString() : "";
                    tb_birth.Text = data.ContainsKey("DateOfBirth") ? data["DateOfBirth"].ToString() : "";
                    tb_mail.Text = data.ContainsKey("Mail") ? data["Mail"].ToString() : "";
                    tb_phonenum.Text = data.ContainsKey("PhoneNumber") ? data["PhoneNumber"].ToString() : "";

                    if (data.ContainsKey("Avatar_url"))
                    {
                        string avatarUrl =data["Avatar_url"].ToString();
                        await DisplayAvatar(avatarUrl);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin giảng viên.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin giảng viên: " + ex.Message);
            }
        }

        private async void btn_UpLoadAva_Click(object sender, EventArgs e)
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
                    string maso = DangNhap.maso;
                    string objectName = $"{maso}/avatar.png"; // Tên object để lưu trữ ảnh

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        await storageClient.UploadObjectAsync(bucketName, objectName, null, fileStream);
                    }

                    // Cập nhật URL avatar mới vào Firestore
                    string newAvatarUrl = $"gs://{bucketName}/{objectName}";
                    DocumentReference docRef = db.Collection("InfoTeacher").Document(maso);
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

    }
}
