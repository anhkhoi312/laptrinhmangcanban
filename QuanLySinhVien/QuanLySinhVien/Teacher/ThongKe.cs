using System;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    public partial class ThongKe : Form
    {
        FirestoreDb firestoreDb;


        public class Student
        {
            public string Mssv { get; set; }
            public Dictionary<string, object> Grade { get; set; }
        }


        public ThongKe()
        {
            InitializeComponent();
            string projectId = "ltmcb-7d1a6";
            firestoreDb = FirestoreDb.Create(projectId);
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

        private void ThongKe_Load(object sender, EventArgs e)
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



        private async Task<int> CountStudentsInClassAsync(string className)
        {
            int studentCount = 0;
            DocumentReference classRef = firestoreDb.Collection("InfoClasses").Document(className);
            DocumentSnapshot classSnapshot = await classRef.GetSnapshotAsync();
            if (classSnapshot.Exists)
            {
                List<object> studentList = classSnapshot.GetValue<List<object>>("StudentList");
                studentCount = studentList.Count;
            }

            return studentCount;
        }

        


        // ---------------------------------------------------------
        private async Task<List<Student>> GetStudentsInClassAsync(string className)
        {
            List<Student> students = new List<Student>();
            QuerySnapshot querySnapshot = await firestoreDb.Collection("InfoStudent").GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                string mssv = documentSnapshot.Id;
                DocumentReference gradeRef = firestoreDb.Collection("InfoStudent").Document(mssv).Collection("Grade").Document(className);
                DocumentSnapshot gradeSnapshot = await gradeRef.GetSnapshotAsync();
                if (gradeSnapshot.Exists)
                {
                    Dictionary<string, object> gradeData = gradeSnapshot.ToDictionary();
                    Student student = new Student
                    {
                        Mssv = mssv,
                        Grade = gradeData
                    };
                    students.Add(student);
                }
            }
            return students;
        }

        private async Task UpdateListViewWithStudentGrades(string className)
        {
            try
            {

                List<Student> students = await GetStudentsInClassAsync(className);
                dataGridView1.Rows.Clear(); // Xóa nội dung cũ

                foreach (var student in students)
                {
                    // Tạo một hàng mới cho sinh viên
                    int rowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    // Đặt giá trị của các ô cột
                    row.Cells["MSSV"].Value = student.Mssv;

                    // Truy cập dữ liệu điểm của sinh viên cho lớp đã chọn
                    var grades = student.Grade;
                    if (grades != null)
                    {
                        row.Cells["QT"].Value = grades.ContainsKey("QT") ? grades["QT"].ToString() : "N/A";
                        row.Cells["GK"].Value = grades.ContainsKey("GK") ? grades["GK"].ToString() : "N/A";
                        row.Cells["CK"].Value = grades.ContainsKey("CK") ? grades["CK"].ToString() : "N/A";
                        row.Cells["TBM"].Value = grades.ContainsKey("TBM") ? grades["TBM"].ToString() : "N/A";

                        double tbm = double.Parse(row.Cells["TBM"].Value.ToString());
                        if (tbm < 5)
                        {
                            row.Cells["Type"].Value = "F";
                        }
                        else if (tbm >=5 && tbm<6)
                        {
                            row.Cells["Type"].Value = "C";
                        }
                        else if (tbm >= 6 && tbm < 7)
                        {
                            row.Cells["Type"].Value = "B";
                        }
                        else if (tbm >= 7 && tbm < 8)
                        {
                            row.Cells["Type"].Value = "B+";
                        }
                        else if (tbm >= 8 && tbm < 9)
                        {
                            row.Cells["Type"].Value = "A";
                        }
                        else if (tbm >= 9 && tbm <=10)
                        {
                            row.Cells["Type"].Value = "A+";
                        }
                    }
                    else
                    {
                        // Nếu không có điểm, đặt giá trị mặc định là "N/A"
                        row.Cells["QT"].Value = "N/A";
                        row.Cells["GK"].Value = "N/A";
                        row.Cells["CK"].Value = "N/A";
                        row.Cells["TBM"].Value = "N/A";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void tracuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị thông báo đang tải dữ liệu
                dataGridView1.Rows.Clear();
                int temp = dataGridView1.Rows.Add();
                DataGridViewRow loadingRow = dataGridView1.Rows[temp];
                loadingRow.Cells["MSSV"].Value = "Đang lấy dữ liệu...";

                // lấy tên lớp được chọn từ comboBox
                string selectedClassName = comboBox_mssv.SelectedItem.ToString();

                int count = await CountStudentsInClassAsync(selectedClassName);
                textBox1.Text = count.ToString();
                await UpdateListViewWithStudentGrades(selectedClassName);
                int passedCount = 0;
                int failedCount = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["TBM"].Value != null && row.Cells["TBM"].Value.ToString() != "N/A")
                    {
                        double ckScore;
                        if (double.TryParse(row.Cells["TBM"].Value.ToString(), out ckScore))
                        {
                            if (ckScore >= 5)
                                passedCount++;
                            else
                                failedCount++;
                        }
                    }
                }

                // Hiển thị số lượng sinh viên qua môn và rớt môn
                tb_quamon.Text = passedCount.ToString();
                tb_rotmon.Text = failedCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
