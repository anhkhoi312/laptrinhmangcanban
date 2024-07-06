using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Teacher
{
    public partial class giaoTask : Form
    {
        private string uploadedFilePath;

        public giaoTask()
        {
            InitializeComponent();
            LoadClasses(); // tải danh sách lớp học
        }

        private async void LoadClasses()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5000/api/classes");
                if (response.IsSuccessStatusCode)
                {
                    var classes = await response.Content.ReadFromJsonAsync<List<string>>();
                    comboBoxClasses.Items.Clear();
                    foreach (var className in classes)
                    {
                        comboBoxClasses.Items.Add(className);
                    }
                    // Thêm dòng này để kiểm tra dữ liệu
                    MessageBox.Show("Classes loaded successfully: " + string.Join(", ", classes));
                }
                else
                {
                    MessageBox.Show("Không thể tải danh sách lớp học.");
                }
            }
        }

        private async void LoadDeadlines(string classId)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"http://localhost:5000/api/classes/{classId}/deadlines");
                if (response.IsSuccessStatusCode)
                {
                    var deadlines = await response.Content.ReadFromJsonAsync<List<DeadlineModel>>();
                    listBoxDeadlines.Items.Clear();
                    foreach (var deadline in deadlines)
                    {
                        listBoxDeadlines.Items.Add(deadline);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể tải danh sách deadlines.");
                }
            }
        }

        private void comboBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedClass = comboBoxClasses.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedClass))
            {
                LoadDeadlines(selectedClass);
            }
        }


        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (listBoxStudents.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một submission.");
                return;
            }

            var selectedSubmission = listBoxStudents.SelectedItem as SubmissionModel;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"http://localhost:5000/api/deadlines/submission/download/{selectedSubmission.Id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var fileUrlResponse = System.Text.Json.JsonDocument.Parse(jsonResponse);
                    var fileUrl = fileUrlResponse.RootElement.GetProperty("url").GetString();

                    using (var downloadClient = new HttpClient())
                    {
                        var fileBytes = await downloadClient.GetByteArrayAsync(fileUrl);
                        var fileName = Path.GetFileName(fileUrl);
                        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

                        await Task.Run(() => System.IO.File.WriteAllBytes(filePath, fileBytes));
                        MessageBox.Show("File downloaded successfully.");
                    }
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Không thể tải file submission. Error: {responseContent}");
                }
            }
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uploadedFilePath))
            {
                MessageBox.Show("Vui lòng chọn file bài tập.");
                return;
            }

            // Tạo một deadline mới
            var deadline = new CreateDeadlineModel
            {
                Title = txtTitle.Text,
                DeadlineDate = dateTimePicker.Value, // Lưu giá trị DateTime trực tiếp
                ClassID = comboBoxClasses.SelectedItem.ToString()
            };

            using (HttpClient client = new HttpClient())
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(deadline.Title), "Title");
                form.Add(new StringContent(deadline.DeadlineDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")), "DeadlineDate"); // Chuyển DateTime thành chuỗi
                form.Add(new StringContent(deadline.ClassID), "ClassID");

                using (var fileStream = new FileStream(uploadedFilePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "file", Path.GetFileName(uploadedFilePath));
                    HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/Deadlines/add", form);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Deadline added successfully.");
                        LoadDeadlines(comboBoxClasses.SelectedItem.ToString()); // Tải lại danh sách deadlines
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error: {responseContent}");
                    }
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                uploadedFilePath = openFileDialog1.FileName;
                lblFileName.Text = Path.GetFileName(uploadedFilePath);
            }
        }

        private void listBoxDeadlines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDeadlines.SelectedItem != null)
            {
                DeadlineModel selectedDeadline = listBoxDeadlines.SelectedItem as DeadlineModel;
                if (selectedDeadline != null)
                {
                    MessageBox.Show($"Deadline Details:\nTitle: {selectedDeadline.Title}\nDue Date: {selectedDeadline.DeadlineDate}\nFile URL: {selectedDeadline.FileUrl}");
                }
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void loadDL_Click(object sender, EventArgs e)
        {

        }

        private async void btnCheck_Click_1(object sender, EventArgs e)
        {
            if (listBoxDeadlines.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một deadline.");
                return;
            }

            var selectedDeadline = listBoxDeadlines.SelectedItem as DeadlineModel;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"http://localhost:5000/api/deadlines/{selectedDeadline.Id}/submissions");
                if (response.IsSuccessStatusCode)
                {
                    var submissions = await response.Content.ReadFromJsonAsync<List<SubmissionModel>>();
                    listBoxStudents.Items.Clear();
                    foreach (var submission in submissions)
                    {
                        listBoxStudents.Items.Add(submission);
                    }
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Không thể tải danh sách submissions. Error: {responseContent}");
                }
            }
        }

        private void giaoTask_Load(object sender, EventArgs e)
        {

        }
    }
}
