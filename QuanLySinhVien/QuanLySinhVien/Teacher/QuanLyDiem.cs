using FireSharp;
using FireSharp.Interfaces;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLySinhVien
{
    public partial class QuanLyDiem : Form
    {
        FirestoreDb firestoreDb;

        string teacherId;

        public class Student
        {
            public string Mssv { get; set; }

            public Dictionary<string, object> Grade { get; set; }
        }


        public QuanLyDiem()
        {
            InitializeComponent();
            string projectId = "ltmcb-7d1a6";
            firestoreDb = FirestoreDb.Create(projectId);
            teacherId = DangNhap.maso;
        }

        private async void QuanLyDiem_Load(object sender, EventArgs e)
        {
            try
            {
                CollectionReference infoTeacherRef = firestoreDb.Collection("InfoTeacher");
                DocumentReference docRef = infoTeacherRef.Document(teacherId);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                List<string> manage = snapshot.GetValue<List<string>>("Manage");
                if (manage != null && manage.Count > 0)
                {
                    comboBox_mssv.Items.AddRange(manage.ToArray());
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button_capnhat_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                string path = openFileDialog.FileName.ToString();
                DataTable dt = Doc_Excel(path);
                // lấy tên lớp được chọn từ comboBox
                string selectedClassName = comboBox_mssv.SelectedItem.ToString();
                List<Student> students = await GetStudentsInClassByExcelAsync(selectedClassName, dt);

                await UpdateListViewWithStudentGrades(selectedClassName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        
        private async void comboBox_mssv_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedClassName = comboBox_mssv.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedClassName))
            {
                await UpdateListViewWithStudentGrades(selectedClassName);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp");
            } 
                
        }



        // Hàm lấy danh sách sinh viên------------------------------------------------------------------------

                //Hàm lấy danh sách từ firebase
        private async Task<List<Student>> GetStudentAsync(string className)
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
                //Hàm thêm điểm sinh viên từ excel
        private async Task<List<Student>> GetStudentsInClassByExcelAsync(string className, DataTable dt)
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
                    DataTable table = dt;

                    foreach (DataRow row in table.Rows)
                    {

                        if (mssv == row[0].ToString())
                        {
                            // Lấy điểm từ TextBox
                            float grade_QT = float.Parse(row[1].ToString());
                            float grade_GK = float.Parse(row[2].ToString());
                            float grade_CK = float.Parse(row[3].ToString());
                            double grade_TBM;
                            grade_TBM = (grade_QT * 0.15) + (grade_GK * 0.35) + (grade_CK * 0.5);
                            // Tạo Dictionary chứa dữ liệu điểm
                            Dictionary<string, object> gradeData = new Dictionary<string, object>();
                            gradeData.Add("QT", grade_QT);
                            gradeData.Add("GK", grade_GK);
                            gradeData.Add("CK", grade_CK);
                            gradeData.Add("TBM", grade_TBM);
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
            }
            return students;
        }



                //Hàm thêm điểm sinh viên từ textbox
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
                        float grade_QT = float.Parse(textBox_qt.Text);
                        float grade_GK = float.Parse(textBox_gk.Text);
                        float grade_CK = float.Parse(textBox_ck.Text);
                        double grade_TBM;
                        grade_TBM = (grade_QT * 0.15) + (grade_GK * 0.25) + (grade_CK * 0.5);
                        // Tạo Dictionary chứa dữ liệu điểm
                        Dictionary<string, object> gradeData = new Dictionary<string, object>();
                        gradeData.Add("QT", grade_QT);
                        gradeData.Add("GK", grade_GK);
                        gradeData.Add("CK", grade_CK);
                        gradeData.Add("TBM", grade_TBM);
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

        //Hàm thêm dữ liệu sinh viên vào firebase
        private async Task AddOrUpdateGradeAsync(string mssv, string className, Dictionary<string, object> gradeData)
        {
            // Tham chiếu đến tài liệu của sinh viên trong bộ sưu tập "InfoStudent"
            DocumentReference student = firestoreDb.Collection("InfoStudent").Document(mssv);

            // Tham chiếu đến tài liệu điểm của sinh viên trong bộ sưu tập "Grade"
            DocumentReference grade = student.Collection("Grade").Document(className);

            // Thêm hoặc cập nhật dữ liệu điểm vào Firebase
            await grade.SetAsync(gradeData);
        }



        //Cập nhật danh sách sinh viên từ firebase in lên listview  ------------------------------------------------------------
        private async Task UpdateListViewWithStudentGrades(string className)
        {
            try
            {
                List<Student> students = await GetStudentAsync(className);
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

        //Hàm đọc file excel
        public DataTable Doc_Excel(string path)
        {
            var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);
            var students = reader.AsDataSet();
            var tables = students.Tables.Cast<DataTable>().ToList();

            foreach (DataTable table in tables)
            {
                // Tạo một DataTable mới để chứa dữ liệu từ dòng thứ 2 trở đi
                DataTable newTable = table.Clone();

                // Lặp qua từng dòng (bỏ qua dòng đầu tiên)
                for (int i = 1; i < table.Rows.Count; i++)
                {
                    // Tạo một DataRow mới cho DataTable mới
                    DataRow newRow = newTable.Rows.Add();

                    // Copy dữ liệu từ các ô trong dòng hiện tại sang dòng mới
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        newRow[j] = table.Rows[i][j];
                    }
                }

                return newTable;
            }
            return null;
        }

    }
}
