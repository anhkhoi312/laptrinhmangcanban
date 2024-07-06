using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Student
{
    public partial class Deadline : Form
    {
        private string studentId;
        private string selectedAssignmentId;
        private string uploadedFilePath;
        private Stream fileStream;

        public Deadline(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            openFileDialog1 = new OpenFileDialog(); // Khởi tạo OpenFileDialog
            openFileDialog1.Filter = "All files (*.*)|*.*"; // Cấu hình OpenFileDialog
            LoadAssignments();
        }

        private async void LoadAssignments()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"http://localhost:5000/api/Deadlines/student/assignments/{studentId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var assignments = await response.Content.ReadFromJsonAsync<List<DeadlineModel>>();
                        foreach (var assignment in assignments)
                        {
                            listBoxAssignments.Items.Add(assignment);
                        }
                    }
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Không thể tải danh sách bài tập. Lỗi: {responseContent}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xảy ra: {ex.Message}");
                }
            }
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                uploadedFilePath = openFileDialog1.FileName;
                lblFileName.Text = Path.GetFileName(uploadedFilePath);
                fileStream = new FileStream(uploadedFilePath, FileMode.Open, FileAccess.Read);
                MessageBox.Show($"File selected: {uploadedFilePath}");
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uploadedFilePath))
            {
                MessageBox.Show("Vui lòng chọn file bài tập.");
                return;
            }

            if (string.IsNullOrEmpty(selectedAssignmentId))
            {
                MessageBox.Show("Vui lòng chọn bài tập.");
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(studentId), "studentId");
                form.Add(new StringContent(selectedAssignmentId), "assignmentId");

                using (var fileStream = new FileStream(uploadedFilePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "file", Path.GetFileName(uploadedFilePath));

                    HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/Deadlines/submit", form);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Nộp bài thành công.");
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error: {responseContent}");
                    }
                }
            }
        }

        private void listBoxAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAssignments.SelectedItem != null)
            {
                DeadlineModel selectedAssignment = listBoxAssignments.SelectedItem as DeadlineModel;
                if (selectedAssignment != null)
                {
                    selectedAssignmentId = selectedAssignment.Id; // Sử dụng Document ID
                    txtDeadline.Text = selectedAssignment.DeadlineDate.ToString("dd/MM/yyyy HH:mm:ss"); // Hiển thị deadline trong TextBox
                    Lop.Text= selectedAssignment.ClassID.ToString();
                    MessageBox.Show($"URL của bài tập: {selectedAssignment.FileUrl}"); // Hiển thị URL của bài tập
                }
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (listBoxAssignments.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bài tập.");
                return;
            }

            DeadlineModel selectedAssignment = listBoxAssignments.SelectedItem as DeadlineModel;
            if (selectedAssignment != null)
            {
                MessageBox.Show($"Đang tải xuống từ URL: {selectedAssignment.FileUrl}");
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(selectedAssignment.FileUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
                            string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.GetFileName(selectedAssignment.FileUrl));
                            File.WriteAllBytes(downloadPath, fileBytes);
                            MessageBox.Show("Tải file thành công.");
                        }
                        else
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Tải file thất bại. Trạng thái: {response.StatusCode}, Nội dung phản hồi: {responseContent}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải file: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bài tập này không có file đính kèm.");
            }
        }

        private void Deadline_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
