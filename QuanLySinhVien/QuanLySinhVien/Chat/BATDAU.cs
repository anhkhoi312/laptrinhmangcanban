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
    public partial class BATDAU : Form
    {
        private List<string> availableUsers;
        public static string maso { get; set; }
        public BATDAU()
        {
            InitializeComponent();
            availableUsers = new List<string>();
            InitializeRole();
        }
        private void InitializeRole()
        {
            UpdateAvailableUsers(maso);

            

           // Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InitializeRole();
            if (IsStudent(maso))
            {
                var studentForm = new Chat_Student(maso, availableUsers);
                //  studentForm.Closed += (s, args) => Close();
                 studentForm.Show();
            }
            else if (IsTeacher(maso))
            {
                var teacherForm = new Chat_Teacher(maso, availableUsers);
               //  teacherForm.Closed += (s, args) => Close();
                 teacherForm.Show();
            }
            else
            {
                MessageBox.Show("Mã số không hợp lệ.");
                Close();
            }
        }
        private bool IsStudent(string userId)
        {
            return userId == "22520701" || userId == "22520718" || userId == "22520897" || userId == "22520937" || userId == "22521003" || userId == "22521068" || userId == "22521106" || userId == "22521125";
        }

        private bool IsTeacher(string userId)
        {
            return userId == "GV001" ;
        }
        private void UpdateAvailableUsers(string userId)
        {
            availableUsers.Clear();

            if (userId == "22520701")
            {
                availableUsers.AddRange(new List<string> { "GV001" });
            }
            else if (userId == "22520718")
            {
                availableUsers.AddRange(new List<string> { "GV001" });
            }
            else if (userId == "22520897")
            {
                availableUsers.AddRange(new List<string> { "GV001" });
            }
            else if (userId == "2252937")
            {
                availableUsers.AddRange(new List<string> { "GV001" });
            }
            else if (userId == "22521003")
            {
                availableUsers.AddRange(new List<string> { "GV001" });
            }
            else if (userId == "22521068")
            {
                availableUsers.AddRange(new List<string> { "GV001" });
            }
            else if (userId == "22521106")
            {
                availableUsers.AddRange(new List<string> { "GV001" });
            }
            else if (userId == "22521125")
            {
                availableUsers.AddRange(new List<string> { "GV001" });
            }
            else if (userId == "GV001")
            {
                availableUsers.AddRange(new List<string> { "22520701", "22520718","22520897","22520937","22521003","22521068","22521106","22521125" });
            }
            //else if (userId == "002")
            //{
            //    availableUsers.Add("22520701");
            //}
            //else if (userId == "003")
            //{
            //    availableUsers.Add("22521213");
            //}
            else
            {
                MessageBox.Show("Ma so khong hop le roi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
