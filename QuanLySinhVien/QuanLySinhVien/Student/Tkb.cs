using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien.Student
{
    public partial class Tkb : Form
    {
        string mssv = DangNhap.maso;
        private FirestoreDb firestoreDb = FirestoreDb.Create("ltmcb-7d1a6");

        public Tkb()
        {
            InitializeComponent();
        }

        private void Tkb_Load(object sender, EventArgs e)
        {
            // Thêm cột (Thứ trong tuần)
            dataGridView.Columns.Add("Monday", "Monday");
            dataGridView.Columns.Add("Tuesday", "Tuesday");
            dataGridView.Columns.Add("Wednesday", "Wednesday");
            dataGridView.Columns.Add("Thursday", "Thursday");
            dataGridView.Columns.Add("Friday", "Friday");
            dataGridView.Columns.Add("Saturday", "Saturday");

            // Thêm hàng (Tiết học)
            string[] periods = new string[]
            {
                "Tiết 1\n(7:30 - 8:15)",
                "Tiết 2\n(8:15 - 9:00)",
                "Tiết 3\n(9:00 - 9:45)",
                "Tiết 4\n(10:00 - 10:45)",
                "Tiết 5\n(10:45 - 11:30)",
                "Tiết 6\n(13:00 - 13:45)",
                "Tiết 7\n(13:45 - 14:30)",
                "Tiết 8\n(14:30 - 15:15)",
                "Tiết 9\n(15:30 - 16:15)",
                "Tiết 10\n(16:15 - 17:00)"
            };

            for (int i = 0; i < periods.Length; i++)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].HeaderCell.Value = periods[i];
            }

            // Đăng ký sự kiện CellPainting
            dataGridView.CellPainting += dataGridView_CellPainting;

            // Gọi hàm LoadSchedule
            LoadSchedule(dataGridView);
        }

        private async void LoadSchedule(DataGridView dataGridView)
        {
            try
            {
                // Reference đến tài liệu sinh viên trong bảng "InfoStudent"
                DocumentReference sinhVienRef = firestoreDb.Collection("InfoStudent").Document(mssv);
                CollectionReference gradeRef = sinhVienRef.Collection("Grade");

                // Lấy danh sách các mã môn học
                QuerySnapshot gradeSnapshot = await gradeRef.GetSnapshotAsync();
                List<string> maMonHocList = new List<string>();

                foreach (DocumentSnapshot gradeDoc in gradeSnapshot.Documents)
                {
                    maMonHocList.Add(gradeDoc.Id);
                }

                // Lấy thông tin lịch học từ các mã môn học
                Dictionary<string, List<Tuple<int, string>>> scheduleData = new Dictionary<string, List<Tuple<int, string>>>();
                foreach (string maMonHoc in maMonHocList)
                {
                    DocumentReference classRef = firestoreDb.Collection("InfoClasses").Document(maMonHoc);
                    DocumentSnapshot classSnapshot = await classRef.GetSnapshotAsync();

                    if (classSnapshot.Exists)
                    {
                        Dictionary<string, object> classData = classSnapshot.ToDictionary();
                        string subjectName = classData.ContainsKey("Obj") ? classData["Obj"].ToString() : "Unknown";

                        if (classData.ContainsKey("schedule") && classData["schedule"] is List<object> scheduleList)
                        {
                            foreach (var scheduleItem in scheduleList)
                            {
                                if (scheduleItem is Dictionary<string, object> item)
                                {
                                    string dayNumber = item["day"].ToString();
                                    string periods = item["period"].ToString();
                                    string room = item["room"].ToString();

                                    string day = GetDayOfWeek(dayNumber);

                                    if (!scheduleData.ContainsKey(day))
                                    {
                                        scheduleData[day] = new List<Tuple<int, string>>();
                                    }

                                    foreach (char periodChar in periods)
                                    {
                                        if (char.IsDigit(periodChar))
                                        {
                                            int periodNumber = int.Parse(periodChar.ToString());
                                            scheduleData[day].Add(Tuple.Create(periodNumber, $"{subjectName}\n{room}"));
                                        }
                                    }

                                    if (periods.Contains("10"))
                                    {
                                        scheduleData[day].Add(Tuple.Create(10, $"{subjectName}\n{room}"));
                                    }
                                }
                            }
                        }
                    }
                }

                // Hiển thị dữ liệu lên DataGridView
                foreach (var dayEntry in scheduleData)
                {
                    string day = dayEntry.Key;
                    List<Tuple<int, string>> daySchedules = dayEntry.Value;

                    daySchedules.Sort((x, y) => x.Item1.CompareTo(y.Item1));

                    int startPeriod = -1;
                    int endPeriod = -1;
                    string currentSubject = null;

                    foreach (var entry in daySchedules)
                    {
                        int periodNumber = entry.Item1;
                        string subjectName = entry.Item2;

                        if (currentSubject == null || currentSubject != subjectName)
                        {
                            if (startPeriod != -1)
                            {
                                MergeCells(dataGridView, startPeriod, endPeriod, day, currentSubject);
                            }

                            startPeriod = periodNumber;
                            endPeriod = periodNumber;
                            currentSubject = subjectName;
                        }
                        else
                        {
                            endPeriod = periodNumber;
                        }
                    }

                    if (startPeriod != -1)
                    {
                        MergeCells(dataGridView, startPeriod, endPeriod, day, currentSubject);
                    }
                }

                // Vẽ lại DataGridView
                dataGridView.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void MergeCells(DataGridView dataGridView, int startPeriod, int endPeriod, string day, string subject)
        {
            if (startPeriod <= endPeriod)
            {
                dataGridView.Rows[startPeriod - 1].Cells[day].Value = subject;
                dataGridView.Rows[startPeriod - 1].Cells[day].Tag = new Tuple<int, int>(startPeriod, endPeriod); // Range

                for (int i = startPeriod; i <= endPeriod; i++)
                {
                    if (i != startPeriod)
                    {
                        dataGridView.Rows[i - 1].Cells[day].Value = "";
                        dataGridView.Rows[i - 1].Cells[day].Tag = -1; // This cell is merged
                    }
                }
            }
        }

        private string GetDayOfWeek(string dayNumber)
        {
            switch (dayNumber)
            {
                case "2":
                    return "Monday";
                case "3":
                    return "Tuesday";
                case "4":
                    return "Wednesday";
                case "5":
                    return "Thursday";
                case "6":
                    return "Friday";
                case "7":
                    return "Saturday";
                default:
                    return "";
            }
        }

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag is int span && span == -1)
            {
                e.Handled = true;
                return;
            }

            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag is Tuple<int, int> range)
            {
                int startRow = range.Item1 - 1;
                int endRow = range.Item2 - 1;

                if (startRow < 0 || endRow >= dataGridView.RowCount)
                {
                    e.Handled = true;
                    return;
                }

                Rectangle rect = new Rectangle(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width, e.CellBounds.Height);

                for (int i = startRow; i <= endRow && i < dataGridView.RowCount; i++)
                {
                    rect.Height += dataGridView.Rows[i].Height;
                }

                e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), rect);
                e.Graphics.DrawRectangle(Pens.Black, rect);
                e.Graphics.DrawString(dataGridView.Rows[startRow].Cells[e.ColumnIndex].Value.ToString(), e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), rect, StringFormat.GenericDefault);
                e.Handled = true;
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.CellBounds);
                e.Graphics.DrawRectangle(Pens.Black, e.CellBounds);

                if (!string.IsNullOrEmpty((string)e.Value))
                {
                    e.Graphics.DrawString((string)e.Value, e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), e.CellBounds, StringFormat.GenericDefault);
                }
                e.Handled = true;
            }
        }
    }
}
