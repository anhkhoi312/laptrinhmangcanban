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
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var assignments = await response.Content.ReadFromJsonAsync<List<DeadlineModel>>();
                        // Hiển thị danh sách bài tập lên ListView hoặc DataGridView
                        foreach (var assignment in assignments)
                        {
                            // Thêm các bài tập vào giao diện
                            listBoxAssignments.Items.Add(assignment.Title); // Ví dụ sử dụng ListBox
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


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                uploadedFilePath = openFileDialog1.FileName;
                lblFileName.Text = Path.GetFileName(uploadedFilePath);
                fileStream = new FileStream(uploadedFilePath, FileMode.Open, FileAccess.Read);
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
                selectedAssignmentId = listBoxAssignments.SelectedItem.ToString(); // Lấy ID bài tập được chọn
            }
        }

        private void Deadline_Load(object sender, EventArgs e)
        {

        }
    }
}
