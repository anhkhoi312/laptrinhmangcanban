using FireSharp;
using FireSharp.Interfaces;
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
    public partial class QuanLyDiem : Form
    {
        FirestoreDb firestoreDb;


        public class Student
        {
            public string Mssv { get; set; }
            
            public Dictionary<string, object> Grade { get; set; }
        }

        public class Grade
        {
            public int QT { get; set; }
            public int GK { get; set; }
            public int CK { get; set; }
            
        }
        public QuanLyDiem()
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

        private void QuanLyDiem_Load(object sender, EventArgs e)
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

        private async void button_them_Click(object sender, EventArgs e)
        {

            try
            {  // lấy tên lớp được chọn từ comboBox
                string selectedClassName = comboBox_mssv.SelectedItem.ToString();
                List<Student> students = await GetStudentsInClassAsync(selectedClassName);
                
                await UpdateListViewWithStudentGrades(selectedClassName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        private async Task AddOrUpdateGradeAsync(string mssv, string className, Dictionary<string, object> gradeData)
        {
            // Tham chiếu đến tài liệu của sinh viên trong bộ sưu tập "InfoStudent"
            DocumentReference student = firestoreDb.Collection("InfoStudent").Document(mssv);

            // Tham chiếu đến tài liệu điểm của sinh viên trong bộ sưu tập "Grade"
            DocumentReference grade = student.Collection("Grade").Document(className);

            // Thêm hoặc cập nhật dữ liệu điểm vào Firebase
            await grade.SetAsync(gradeData);
        }


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
                    if (mssv == textBox_mssv.Text)
                    {
                        // Lấy điểm từ TextBox
                        string grade_QT = textBox_qt.Text;
                        string grade_GK = textBox_gk.Text;
                        string grade_CK = textBox_ck.Text;
                        // Tạo Dictionary chứa dữ liệu điểm
                        Dictionary<string, object> gradeData = new Dictionary<string, object>();
                        gradeData.Add("QT", grade_QT);
                        gradeData.Add("GK", grade_GK);
                        gradeData.Add("CK", grade_CK);
                        Student student = new Student
                        {
                            Mssv = mssv,
                            Grade = gradeData
                        };
                        students.Add(student);

                        // Thêm hoặc cập nhật dữ liệu điểm của sinh viên vào Firebase
                        await AddOrUpdateGradeAsync(mssv, className, gradeData);
                    }
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
                    }
                    else
                    {
                        // Nếu không có điểm, đặt giá trị mặc định là "N/A"
                        row.Cells["QT"].Value = "N/A";
                        row.Cells["GK"].Value = "N/A";
                        row.Cells["CK"].Value = "N/A";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
