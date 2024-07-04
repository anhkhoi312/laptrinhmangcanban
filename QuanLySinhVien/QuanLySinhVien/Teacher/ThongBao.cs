using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace QuanLySinhVien
{
    public partial class ThongBao : Form
    {
        private FirestoreDb db = FirestoreDb.Create("ltmcb-7d1a6");
        private string teacherId;
        public ThongBao()
        {
            InitializeComponent();
            teacherId = DangNhap.maso;
            InitializeRichTextBox();
        }

        private async Task ShowNotifications(string teacherId)
        {
            try
            {
                DocumentReference teacherRef = db.Collection("InfoTeacher").Document(teacherId);
                DocumentSnapshot teacherSnapshot = await teacherRef.GetSnapshotAsync();
                List<string> notifications = teacherSnapshot.GetValue<List<string>>("Noti");

                if (notifications != null && notifications.Count > 0)
                {
                    notifications.Reverse(); // Đảo ngược danh sách để hiển thị thông báo mới nhất lên trên
                    string separator = new string('-', 125);
                    string joinedNotifications = string.Join($"\n\n{separator}\n\n", notifications);
                    richTextBox2.Text = joinedNotifications;
                }
                else
                {
                    richTextBox2.Text = "Bạn chưa có thông báo nào.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi hiển thị thông báo: " + ex.Message);
            }
        }

        private async Task SaveNoti(string teacherId, string notification)
        {
            try
            {
                DocumentReference teacherRef = db.Collection("InfoTeacher").Document(teacherId);
                DocumentSnapshot teacherSnapshot = await teacherRef.GetSnapshotAsync();
                List<string> notifications = teacherSnapshot.GetValue<List<string>>("Noti") ?? new List<string>();
                notifications.Add(notification);
                await teacherRef.UpdateAsync("Noti", notifications);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu thông báo: " + ex.Message);
            }
        }

        private async void SendMessageToClass(string className, string message)
        {
            try
            {
                DocumentReference classRef = db.Collection("InfoClasses").Document(className);
                DocumentSnapshot classSnapshot = await classRef.GetSnapshotAsync();

                if (classSnapshot.Exists)
                {
                    List<string> studentList = classSnapshot.GetValue<List<string>>("StudentList");
                    if (studentList != null && studentList.Count > 0)
                    {
                        foreach (string studentId in studentList)
                        {
                            DocumentReference studentRef = db.Collection("InfoStudent").Document(studentId);
                            DocumentSnapshot studentSnapshot = await studentRef.GetSnapshotAsync();
                            if (studentSnapshot.Exists)
                            {
                                List<string> messages = studentSnapshot.GetValue<List<string>>("Messages");
                                if (messages == null)
                                {
                                    messages = new List<string>();
                                }
                                messages.Add(message);
                                await studentRef.UpdateAsync("Messages", messages);
                            }
                            else
                            {
                                MessageBox.Show($"Không tìm thấy thông tin sinh viên với mã số {studentId}");
                            }
                        }
                        MessageBox.Show("Đã gửi thông báo thành công cho lớp " + className);
                    }
                    else
                    {
                        MessageBox.Show("Lớp không có sinh viên nào.");
                    }
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy thông tin lớp {className}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void InitializeRichTextBox()
        {
            // Thiết lập nội dung mặc định hoặc gợi ý
            richTextBox1.Text = "Nhập nội dung thông báo";

            // Gắn sự kiện GotFocus để xóa nội dung gợi ý khi control nhận focus
            richTextBox1.GotFocus += RichTextBox_GotFocus;
        }

        private void RichTextBox_GotFocus(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Nhập nội dung thông báo")
            {
                richTextBox1.Text = string.Empty;
            }
        }

        private async void btSend_Click(object sender, EventArgs e)
        {
            string className = comboBox1.SelectedItem?.ToString();
            string time = DateTime.Now.ToString();
            string messageContent = richTextBox1.Text;
            if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(messageContent))
            {
                DocumentReference classRef = db.Collection("InfoClasses").Document(className);
                DocumentSnapshot classSnapshot = await classRef.GetSnapshotAsync();
                string obj = classSnapshot.GetValue<string>("Obj");
                // Tạo chuỗi message với phần in đậm
                string message = $"[{time}]\n{className}({obj})\n{messageContent}";

                SendMessageToClass(className, message);
                string maso = DangNhap.maso;
                await SaveNoti(maso, message);
            }
            else
            {
                if (string.IsNullOrEmpty(className))
                {
                    MessageBox.Show("Vui lòng chọn lớp.");
                }
                else if (string.IsNullOrEmpty(messageContent))
                {
                    MessageBox.Show("Vui lòng nhập nội dung.");
                }
            }

        }

        private async void bt_ListNoti_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "ĐANG LẤY NỘI DUNG VUI LÒNG CHỜ 1 CHÚT..";
            string maso = DangNhap.maso;
            await ShowNotifications(maso);
            richTextBox2.ReadOnly = true; // Ngăn người dùng chỉnh sửa nội dung
        }

        private async void ThongBao_Load(object sender, EventArgs e)
        {
            try
            {
                CollectionReference infoTeacherRef = db.Collection("InfoTeacher");
                DocumentReference docRef = infoTeacherRef.Document(teacherId);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                List<string> manage = snapshot.GetValue<List<string>>("Manage");
                if (manage != null && manage.Count > 0)
                {
                    comboBox1.Items.AddRange(manage.ToArray());
                }
                else
                {
                    MessageBox.Show("Bạn đang không quản lý lớp nào !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải danh sách lớp: " + ex.Message);
            }
        }

    }
}
