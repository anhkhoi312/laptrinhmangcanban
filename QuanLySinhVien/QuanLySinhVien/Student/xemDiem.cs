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
                    double totalTBMxTC = 0;
                    int totalTC = 0;

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

                        // Lấy giá trị của cột "TC" từ "InfoClasses"
                        int tc = await GetTCFromInfoClasses(maMonHoc);
                        row.Cells["TC"].Value = tc.ToString();

                        // Cập nhật tổng TBMxTC và tổng số tín chỉ
                        if (diem.ContainsKey("TBM"))
                        {
                            double tbm = Convert.ToDouble(diem["TBM"]);
                            totalTBMxTC += tbm * tc;
                            totalTC += tc;
                        }
                    }
                    // Tính trung bình chung
                    double averageTBM = totalTBMxTC / totalTC;

                    // Thêm hàng trung bình chung vào cuối bảng điểm
                    int averageRowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow averageRow = dataGridView1.Rows[averageRowIndex];
                    averageRow.Cells["MA_MH"].Value = "Trung bình chung";
                    averageRow.Cells["TC"].Value = averageTBM.ToString();

                    //XẾP LOẠI
                    if (averageTBM < 3)
                    {
                        averageRow.Cells["QT"].Value = "F";
                    }
                    if (averageTBM >= 3 && averageTBM < 4)
                    {
                        averageRow.Cells["QT"].Value = "D (Kém)";
                    }
                    if (averageTBM >= 4 && averageTBM < 5)
                    {
                        averageRow.Cells["QT"].Value = "D+ (Yếu)";
                    }
                    else if (averageTBM >= 5 && averageTBM < 6)
                    {
                        averageRow.Cells["QT"].Value = "C (Trung bình)";
                    }
                    else if (averageTBM >= 6 && averageTBM < 7)
                    {
                        averageRow.Cells["QT"].Value = "B (TB Khá)";
                    }
                    else if (averageTBM >= 7 && averageTBM < 8)
                    {
                        averageRow.Cells["QT"].Value = "B+ (Khá)";
                    }
                    else if (averageTBM >= 8 && averageTBM < 9)
                    {
                        averageRow.Cells["QT"].Value = "A (Giỏi)";
                    }
                    else if (averageTBM >= 9 && averageTBM <= 10)
                    {
                        averageRow.Cells["QT"].Value = "A+ (Xuất sắc)";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật DataGridView: " + ex.Message);
            }
        }

        private async Task<int> GetTCFromInfoClasses(string maMonHoc)
        {
            try
            {
                // Reference đến tài liệu lớp học trong bảng "InfoClasses"
                DocumentReference lopHocRef = Db.Collection("InfoClasses").Document(maMonHoc);

                // Lấy dữ liệu từ tài liệu lớp học
                DocumentSnapshot docSnapshot = await lopHocRef.GetSnapshotAsync();

                // Kiểm tra xem tài liệu có tồn tại không
                if (docSnapshot.Exists)
                {
                    // Lấy giá trị của trường "TC" từ tài liệu
                    int tc = docSnapshot.GetValue<int>("TC");
                    return tc;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ InfoClasses: " + ex.Message);
                return 0;
            }
        }

        private async void xemDiem_Load_1(object sender, EventArgs e)
        {
            string mssv = DangNhap.maso;
            await UpdateListViewWithStudentGrades(mssv);
        }
    }
}
