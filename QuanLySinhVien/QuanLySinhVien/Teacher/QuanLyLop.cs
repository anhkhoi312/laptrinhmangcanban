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

namespace QuanLySinhVien
{
    public partial class QuanLyLop : Form
    {
        FirestoreDb firestoreDb;


        public class Student
        {
            public string Mssv { get; set; }
            public Dictionary<string, object> info { get; set; }


        }

        public QuanLyLop()
        {
            InitializeComponent();
            string projectId = "ltmcb-7d1a6";
            firestoreDb = FirestoreDb.Create(projectId);
        }

        private void button3_nhapfileexcel_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private Task<List<string>> GetClassesAsync()
        {
            return firestoreDb.Collection("InfoClasses").GetSnapshotAsync()
                .ContinueWith(queryTask =>
                {
                    List<string> classNames = new List<string>();
                    QuerySnapshot querySnapshot = queryTask.Result;
                    foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                    {
                        string className = documentSnapshot.Id;
                        classNames.Add(className);
                    }
                    return classNames;
                });
        }

     

        private async Task AddStudentAsync(string classId, string mssv)
        {
            // Tham chiếu đến tài liệu của lớp trong bộ sưu tập "InfoClass"
            DocumentReference classRef = firestoreDb.Collection("InfoClass").Document(classId);

            DocumentSnapshot classSnapshot = await classRef.GetSnapshotAsync();
            List<string> studentList = new List<string>();
            if (classSnapshot.Exists)
            {
                studentList = classSnapshot.GetValue<List<string>>("StudentList");
            }

            // Thêm mssv của sinh viên mới vào danh sách
            studentList.Add(mssv);

            // Cập nhật lại danh sách sinh viên trong tài liệu
            await classRef.SetAsync(new { StudentList = studentList }, SetOptions.MergeAll);
        }

        private async Task<List<string>> GetStudentsInClassAsync(string classId)
        {
            // Tham chiếu đến tài liệu của lớp trong bộ sưu tập "InfoClass"
            DocumentReference classRef = firestoreDb.Collection("InfoClass").Document(classId);

            DocumentSnapshot classSnapshot = await classRef.GetSnapshotAsync();
            List<string> studentList = new List<string>();
            if (classSnapshot.Exists)
            {
                studentList = classSnapshot.GetValue<List<string>>("StudentList");
            }

            return studentList;
        }


        private async Task<List<Student>> GetStudentsAsync(string classId)
        {
            List<Student> students = new List<Student>();
            List<string> studentList = new List<string>();
            studentList = await GetStudentsInClassAsync(classId);
            foreach (string mssv in studentList)
            {
                DocumentSnapshot studentSnapshot = await firestoreDb.Collection("InfoStudent").Document(mssv).GetSnapshotAsync();

                if (studentSnapshot.Exists)
                {
                    // Lấy thông tin sinh viên từ tài liệu Firestore
                    string hoTen = studentSnapshot.GetValue<string>("Name");
                    string soDienThoai = studentSnapshot.GetValue<string>("PhoneNumber");
                    string email = studentSnapshot.GetValue<string>("Mail");
                    Dictionary<string, object> infoData = new Dictionary<string, object>();
                    infoData.Add("Name", hoTen);
                    infoData.Add("PhoneNumber", soDienThoai);
                    infoData.Add("Mail", email);
                    // Tạo đối tượng sinh viên và thêm vào danh sách
                    Student student = new Student
                    {
                        Mssv = mssv,
                        info = infoData
                    };
                    students.Add(student);
                }

            }

            return students;
        }

        private async Task UpdateListViewWithStudent(string classId)
        {
            List<Student> students = await GetStudentsAsync(classId);
            dataGridView1.Rows.Clear(); // Xóa nội dung cũ

            foreach (var student in students)
            {
                // Tạo một hàng mới cho sinh viên
                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // Đặt giá trị của các ô cột
                row.Cells["MSSV"].Value = student.Mssv;


                // Truy cập dữ liệu điểm của sinh viên cho lớp đã chọn
                var infos = student.info;
                if (infos != null)
                {
                    row.Cells["HoTen"].Value = infos.ContainsKey("Name") ? infos["Name"].ToString() : "N/A";
                    row.Cells["SoDT"].Value = infos.ContainsKey("PhoneNumber") ? infos["PhoneNumber"].ToString() : "N/A";
                    row.Cells["Email"].Value = infos.ContainsKey("Mail") ? infos["Mail"].ToString() : "N/A";

                }
                else
                {
                    // Nếu không có điểm, đặt giá trị mặc định là "N/A"
                    row.Cells["HoTen"].Value = "N/A";
                    row.Cells["SoDT"].Value = "N/A";
                    row.Cells["Email"].Value = "N/A";

                }
            }


        }

       
        private async Task RemoveStudentAsync(string classId, string mssv)
        {
            try
            {
                // Tham chiếu đến tài liệu của lớp trong bộ sưu tập "InfoClass"
                DocumentReference classRef = firestoreDb.Collection("InfoClass").Document(classId);

                // Lấy danh sách sinh viên từ tài liệu lớp
                DocumentSnapshot classSnapshot = await classRef.GetSnapshotAsync();
                List<string> studentList = new List<string>();
                if (classSnapshot.Exists)
                {
                    studentList = classSnapshot.GetValue<List<string>>("StudentList");
                }

                // Xóa mssv của sinh viên khỏi danh sách
                studentList.Remove(mssv);

                // Cập nhật lại danh sách sinh viên trong tài liệu
                await classRef.SetAsync(new { StudentList = studentList }, SetOptions.MergeAll);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void QuanLyLop_Load_1(object sender, EventArgs e)
        {
            Task<List<string>> task = GetClassesAsync();
            task.ContinueWith(completedTask =>
            {
                if (completedTask.Status == TaskStatus.RanToCompletion)
                {
                    List<string> Danhsach = completedTask.Result;
                    comboBox_mssv.DataSource = Danhsach;
                }
                else if (completedTask.IsFaulted)
                {
                    // Xử lý lỗi nếu có
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {  // lấy tên lớp được chọn từ comboBox
                string classId = comboBox_mssv.SelectedItem.ToString();
                string mssv = textBox1.Text;
                await RemoveStudentAsync(classId, mssv);
                await UpdateListViewWithStudent(classId);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void button1_them_Click_1(object sender, EventArgs e)
        {
            // lấy tên lớp được chọn từ comboBox
            string classId = comboBox_mssv.SelectedItem.ToString();
            string mssv = textBox1.Text;
            await AddStudentAsync(classId, mssv);
            await UpdateListViewWithStudent(classId);
        }

   
    }
}
