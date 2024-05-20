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
    public partial class Chat_Teacher : Form
    {
        private FirebaseService firebaseService;
        private string teacherId;
        private List<string> students;
        private string selectedStudentId;
        public Chat_Teacher(string teacherId, List<string> students)
        {
            InitializeComponent();
            this.teacherId = teacherId;
            this.students = students;
            firebaseService = new FirebaseService();

            listBoxStudents.DataSource = students;
            listBoxStudents.SelectedIndexChanged += listBoxStudents_SelectedIndexChanged;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == null) return;

            string conversationId = $"{selectedStudentId}_{teacherId}";
            string messageContent = textBoxMessage.Text.Trim();

            await firebaseService.SendMessageAsync(conversationId, teacherId, messageContent);

            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Chuyển đổi thời gian từ UTC sang giờ Việt Nam
            DateTime utcNow = DateTime.UtcNow;
            DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTimeZone);

            // Định dạng thời gian
            string formattedTime = vietnamTime.ToString("dd-MM-yyyy HH:mm");

            // Thêm tin nhắn vào richTextBox
            richTextBoxMessages.AppendText($"{formattedTime}: {teacherId} - {messageContent}\n");
            textBoxMessage.Clear();
        }

        private async void listBoxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStudentId = listBoxStudents.SelectedItem.ToString();
            string conversationId = $"{selectedStudentId}_{teacherId}";

            var messages = await firebaseService.RetrieveMessagesAsync(conversationId);
            richTextBoxMessages.Clear();
            foreach (var message in messages)
            {
                richTextBoxMessages.AppendText($"{message.timestamp}: {message.sender} - {message.content}\n");
            }
        }

        private void Chat_Teacher_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += button1_KeyDown;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
