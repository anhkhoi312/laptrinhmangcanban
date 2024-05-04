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
using FireSharp;
using FireSharp.Interfaces;

namespace QuanLySinhVien.Student
{
    public partial class xemDiem : Form
    {
        FirestoreDb firestoreDb;


        public class MonHoc
        {

            public string Ma_MH { get; set; }
            public Dictionary<string, object> Grade { get; set; }
        }

        public xemDiem()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async Task<List<MonHoc>> GetGradeAsync(string mssv)
        {
            List<MonHoc> monHocs = new List<MonHoc>();
            DocumentReference student = firestoreDb.Collection("InfoStudent").Document(DangNhap.maso);

            QuerySnapshot querySnapshot = await student.Collection("Grade").GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                string classId = documentSnapshot.Id;
                DocumentReference gradeRef = firestoreDb.Collection("InfoStudent").Document(mssv).Collection("Grade").Document(classId);
                DocumentSnapshot gradeSnapshot = await gradeRef.GetSnapshotAsync();

                if (gradeSnapshot.Exists)
                {
                    // Chuyển dữ liệu điểm từ DocumentSnapshot sang Dictionary
                    Dictionary<string, object> gradeData = documentSnapshot.ToDictionary();

                    MonHoc monHoc = new MonHoc
                    {
                        Ma_MH = classId,
                        Grade = gradeData
                    };
                    monHocs.Add(monHoc);
                }
            }

            return monHocs;
        }


        private async Task UpdateListViewWithStudentGrades(string mssv)
        {
            try
            {
                List<MonHoc> monHocs = await GetGradeAsync(mssv);
                dataGridView1.Rows.Clear(); // Xóa nội dung cũ

                foreach (var monHoc in monHocs)
                {
                    // Tạo một hàng mới cho sinh viên
                    int rowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    // Đặt giá trị của các ô cột
                    row.Cells["MSSV"].Value = mssv;

                    row.Cells["MA_MONHOC"].Value = monHoc.Ma_MH;


                    // Truy cập dữ liệu điểm của sinh viên cho lớp đã chọn
                    var grades = monHoc.Grade;
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

        private async void xemDiem_Load(object sender, EventArgs e)
        {
            string mssv = DangNhap.maso;
            List<MonHoc> monHocs = await GetGradeAsync(mssv);

            await UpdateListViewWithStudentGrades(mssv);


        }
    }
}
