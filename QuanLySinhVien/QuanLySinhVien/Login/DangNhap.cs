using Google.Cloud.Firestore;
using QuanLySinhVien.Classes;
using QuanLySinhVien.Student;
using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class DangNhap : Form
    {

        FirestoreDb db = FirestoreDb.Create("ltmcb-7d1a6");
        public DangNhap()
        {
            InitializeComponent();
        }
        public static string maso {  get; set; }

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

        private void btn_Login_Click(object sender, EventArgs e)
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
            if (data != null)
            {
                if (password == data.Password)
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

        private async void btn_ForgetPass_Click(object sender, EventArgs e)
        {
            string username = UserBox.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocumentReference userDataRef = db.Collection("UserData").Document(username);
            DocumentSnapshot snapshot = await userDataRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                string email = snapshot.GetValue<string>("Mail");

                // Tạo mật khẩu ngẫu nhiên
                string confirmationCode = GenerateConfirmationCode();

                //Gửi mật khẩu mới qua mail
                var fromAddress = new MailAddress("tranthungan1724@gmail.com", "NHÓM 15 - LTMCB");
                var toAddress = new MailAddress(email);
                const string fromPassword = "vohi pgnu fsrt wtoj";
                const string subject = "Ứng dụng quản lý điểm sinh viên - Reset mật khẩu";

                // Nội dung email sử dụng định dạng HTML
                string body = $"<html><body><p>Chào bạn,</p><p>Chúng tôi đã hỗ trợ bạn reset mật khẩu. Đây là mật khẩu mới của bạn: <strong>{confirmationCode}</strong></p><p>Trân trọng!</p><p>Cảm ơn</p></body></html>";

                // Gửi email
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Đặt IsBodyHtml thành true để cho phép sử dụng HTML trong nội dung email
                })
                {
                    smtp.Send(message);
                }

                // Lưu mật khẩu mới 
                await userDataRef.UpdateAsync("Password", confirmationCode);

                MessageBox.Show($"Mật khẩu mới đã được gửi đến email của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tên người dùng không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Tạo mật khẩu ngẫu nhiên
        private string GenerateConfirmationCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
