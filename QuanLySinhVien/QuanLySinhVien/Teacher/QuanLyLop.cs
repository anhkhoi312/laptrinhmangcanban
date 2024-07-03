using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using OfficeOpenXml;
using System.IO.Packaging;


namespace QuanLySinhVien
{
    public partial class QuanLyLop : Form
    {
        FirestoreDb firestoreDb;
        string teacherId;

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
            teacherId = DangNhap.maso;
        }

        private async Task AddStudentAsync(string classId, string mssv)
        {
            // Tham chiếu đến tài liệu của lớp trong bộ sưu tập "InfoClass"
            DocumentReference classRef = firestoreDb.Collection("InfoClasses").Document(classId);

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
            DocumentReference classRef = firestoreDb.Collection("InfoClasses").Document(classId);

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
                    Dictionary<string, object> infoData = new Dictionary<string, object>()
                    {
                         { "Name", hoTen },
                        { "PhoneNumber", soDienThoai },
                        { "Mail", email }
                    };
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


                // Truy cập dữ liệu của sinh viên cho lớp đã chọn
                var infos = student.info;
                if (infos != null)
                {
                    row.Cells["HoTen"].Value = infos.ContainsKey("Name") ? infos["Name"].ToString() : "N/A";
                    row.Cells["SoDT"].Value = infos.ContainsKey("PhoneNumber") ? infos["PhoneNumber"].ToString() : "N/A";
                    row.Cells["Email"].Value = infos.ContainsKey("Mail") ? infos["Mail"].ToString() : "N/A";

                }
                else
                {
                    // Nếu không có dữ liệu, đặt giá trị mặc định là "N/A"
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
                DocumentReference classRef = firestoreDb.Collection("InfoClasses").Document(classId);

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

        private async void QuanLyLop_Load(object sender, EventArgs e)
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
        private async void comboBox_mssv_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedClassName = comboBox_mssv.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedClassName))
            {
                await UpdateListViewWithStudent(selectedClassName);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp");
            }
        }

        private async void button1_them_Click(object sender, EventArgs e)
        {

            // lấy tên lớp được chọn từ comboBox
            string classId = comboBox_mssv.SelectedItem.ToString();
            string mssv = textBox1.Text;
            await AddStudentAsync(classId, mssv);
            await UpdateListViewWithStudent(classId);
        }

        private async void button1_Click(object sender, EventArgs e)
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

        public DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();

            // Thêm các cột vào DataTable
            dataTable.Columns.Add("Mssv");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("PhoneNumber");
            dataTable.Columns.Add("Mail");

            // Thêm các hàng vào DataTable
            foreach (DataGridViewRow dtgvRow in dataGridView1.Rows)
            {
                DataRow row = dataTable.NewRow();
                row["Mssv"] = dtgvRow.Cells[0].Value;
                row["Name"] = dtgvRow.Cells[1].Value;
                row["PhoneNumber"] = dtgvRow.Cells[2].Value;
                row["Mail"] = dtgvRow.Cells[3].Value;
                
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }



        public void ExportDataTableToExcel(DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "D1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "MSSV";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Họ và tên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "SDT";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Email";

            cl4.ColumnWidth = 25;



            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "D3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        

        private async void btn_XuatFile_Click(object sender, EventArgs e)
        {
            string classId = comboBox_mssv.SelectedItem.ToString();
            DataTable dt = CreateDataTable();
            ExportDataTableToExcel(dt, classId, "Danh sách lớp " + classId);

            
        }
    }
}
