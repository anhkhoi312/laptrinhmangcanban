using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.Student
{
    public partial class xemDiem : Form
    {
        private FirestoreDb Db = FirestoreDb.Create("ltmcb-7d1a6");

        public xemDiem()
        {
            InitializeComponent();
        }

        private async Task UpdateListViewWithStudentGrades(string mssv)
        {
            try
            {
                // Reference đến tài liệu sinh viên trong bảng "InfoStudent"
                DocumentReference sinhVienRef = Db.Collection("InfoStudent").Document(mssv);

                // Lấy tất cả các điểm của sinh viên từ subcollection "Grade"
                QuerySnapshot querySnapshot = await sinhVienRef.Collection("Grade").GetSnapshotAsync();

                // Kiểm tra dataGridView1 trước khi cập nhật
                if (dataGridView1 != null)
                {
                    // Xóa dữ liệu cũ trong dataGridView1
                    dataGridView1.Rows.Clear();

                    // Lặp qua từng tài liệu (môn học) trong subcollection "Grade"
                    foreach (DocumentSnapshot docSnapshot in querySnapshot.Documents)
                    {
                        // Lấy ID của môn học (tài liệu con)
                        string maMonHoc = docSnapshot.Id;

                        // Lấy dữ liệu điểm từ tài liệu con
                        Dictionary<string, object> diem = docSnapshot.ToDictionary();

                        // Thêm dữ liệu vào dataGridView1
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];

                        // Thiết lập giá trị cho các cột trong dataGridView1
                        row.Cells["MA_MH"].Value = maMonHoc;
                        row.Cells["QT"].Value = diem.ContainsKey("QT") ? diem["QT"].ToString() : "N/A";
                        row.Cells["GK"].Value = diem.ContainsKey("GK") ? diem["GK"].ToString() : "N/A";
                        row.Cells["CK"].Value = diem.ContainsKey("CK") ? diem["CK"].ToString() : "N/A";
                        row.Cells["TBM"].Value = diem.ContainsKey("TBM") ? diem["TBM"].ToString() : "N/A";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật DataGridView: " + ex.Message);
            }
        }

        private async void xemDiem_Load_1(object sender, EventArgs e)
        {
            string mssv = DangNhap.maso;
            await UpdateListViewWithStudentGrades(mssv);
        }
    }
}
