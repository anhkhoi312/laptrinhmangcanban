using QuanLySinhVien.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.Chat
{
    public partial class Chat_Student : Form
    {
        private FirebaseService firebaseService;
        private string studentId;
        private List<string> teachers;
        private string selectedTeacherId;
        public static string maso { get; set; }
        public Chat_Student(string studentId, List<string> teachers)
        {
            InitializeComponent();
            this.studentId = studentId;
            this.teachers = teachers;
            firebaseService = new FirebaseService();

            listBoxTeachers.DataSource = teachers;
            listBoxTeachers.SelectedIndexChanged += listBoxTeachers_SelectedIndexChanged;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (selectedTeacherId == null) return;

            string conversationId = $"{studentId}_{selectedTeacherId}";
            string messageContent = textBoxMessage.Text.Trim();

            await firebaseService.SendMessageAsync(conversationId, studentId, messageContent);

            // Lấy múi giờ Việt Nam
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Chuyển đổi thời gian từ UTC sang giờ Việt Nam
            DateTime utcNow = DateTime.UtcNow;
            DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTimeZone);

            // Định dạng thời gian
            string formattedTime = vietnamTime.ToString("dd-MM-yyyy HH:mm");

            // Thêm tin nhắn vào richTextBox
            richTextBoxMessages.AppendText($"{formattedTime}: {studentId} - {messageContent}\n");

            textBoxMessage.Clear();
        }

        private async void listBoxTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeacherId = listBoxTeachers.SelectedItem.ToString();
            string conversationId = $"{studentId}_{selectedTeacherId}";

            var messages = await firebaseService.RetrieveMessagesAsync(conversationId);
            richTextBoxMessages.Clear();
            foreach (var message in messages)
            {
                richTextBoxMessages.AppendText($"{message.timestamp}: {message.sender} - {message.content}\n");
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void Chat_Student_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += button1_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
