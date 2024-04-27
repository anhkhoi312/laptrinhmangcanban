using Google.Type;
using System;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QuanLySinhVien;
using System.Threading.Tasks.Sources;


namespace QuanLySinhVien
{
    public partial class ThongBao : Form
    {

        FirestoreDb db = FirestoreDb.Create("ltmcb-7d1a6");
        public ThongBao()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.DateTime now = System.DateTime.Now;
            timerLabel.Text = now.ToString();
        }
        private async void ThongBao_Load(object sender, EventArgs e)
        {
            timer1.Start();

            CollectionReference infoTeacherRef = db.Collection("InfoTeacher");

            string maso = DangNhap.maso;
            DocumentReference docRef = infoTeacherRef.Document(maso);

            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            // Lấy giá trị của trường "Manage" (giả sử trường Manage là một mảng các danh sách lớp)
            List<string> manage = snapshot.GetValue<List<string>>("Manage");
            // Kiểm tra xem mảng manage có dữ liệu không trước khi gán vào ComboBox
            if (manage != null && manage.Count > 0)
            {
                // Gán dữ liệu vào ComboBox
                comboBox1.Items.AddRange(manage.ToArray());
            }
            else
            {
                MessageBox.Show("Bạn đang không quản lý lớp nào !");
            }
        }

        private async void SendMessageToClass(string className, string message)
        {
            try
            {
                // Tìm tài liệu lớp trong collection "InfoClasses " với tên là className
                DocumentReference classRef = db.Collection("InfoClasses").Document(className);
                DocumentSnapshot classSnapshot = await classRef.GetSnapshotAsync();
                if (classSnapshot.Exists)
                {
                    // Lấy danh sách sinh viên từ trường "StudentList"
                    List<string> studentList = classSnapshot.GetValue<List<string>>("StudentList");
                    if (studentList != null && studentList.Count > 0)
                    {
                        // Duyệt qua danh sách sinh viên và gửi tin nhắn cho mỗi sinh viên
                        foreach (string studentId in studentList)
                        {
                            // Tìm tài liệu sinh viên trong collection "InfoStudent" với ID là studentId
                            DocumentReference studentRef = db.Collection("InfoStudent").Document(studentId);
                            DocumentSnapshot studentSnapshot = await studentRef.GetSnapshotAsync();
                            if (studentSnapshot.Exists)
                            {
                                // Gán nội dung tin nhắn vào mảng Messages của sinh viên
                                List<string> messages = studentSnapshot.GetValue<List<string>>("Messages");
                                if (messages == null)
                                {
                                    messages = new List<string>();
                                }
                                messages.Add(message);

                                // Cập nhật lại trường "Messages" của sinh viên
                                await studentRef.UpdateAsync("Messages", messages);
                            }
                            else
                            {
                                MessageBox.Show($"Không tìm thấy thông tin sinh viên với mã số {studentId}");
                            }
                        }
                        MessageBox.Show("Đã gửi tin nhắn thành công cho lớp " + className);
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
        private void btSend_Click(object sender, EventArgs e)
        {
            // Lấy tên lớp và nội dung tin nhắn từ ComboBox và RichTextBox
            string className = comboBox1.SelectedItem?.ToString();
            string time = timerLabel.Text;
            string messageContent = richTextBox1.Text;

            string message = $"[{time}] {className}: {messageContent}";

            // Kiểm tra xem có tên lớp và nội dung tin nhắn không trước khi gửi
            if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(message))
            {
                // Gửi tin nhắn đến lớp
                SendMessageToClass(className, message);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tên lớp và nhập nội dung tin nhắn.");
            }
        }
    }
}
