using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
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

namespace QuanLySinhVien
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UserBox.Text.Trim();
            string password = PassBox.Text;
            var db = FirestoreHelper.database;
            DocumentReference docRef = db.Collection("UserData").Document(data)
        }
    }
}
