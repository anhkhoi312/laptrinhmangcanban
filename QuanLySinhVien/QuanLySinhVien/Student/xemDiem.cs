using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.Student
{
    public partial class xemDiem : Form
    {
        FirestoreDb firestoreDb;


        public class Student
        {
            public string Mssv { get; set; }
            public string Mamh { get; set; }

            public Dictionary<string, object> Grade { get; set; }
        }

        public class Grade
        {
            public int QT { get; set; }
            public int GK { get; set; }
            public int CK { get; set; }

        }
        public xemDiem()
        {
            InitializeComponent();
        }
        private Task<List<string>> GetClassesAsync()
        {
            return firestoreDb.Collection("InfoClasses").GetSnapshotAsync()
                .ContinueWith(queryTask =>
                {
                    List<string> classNames = new List<string>();
                    QuerySnapshot querySnapshot = queryTask.Result;
                    foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                    {
                        string className = documentSnapshot.Id;
                        classNames.Add(className);
                    }
                    return classNames;
                });
        }
        private Task<List<string>> GetStudentAsync()
        {
            return firestoreDb.Collection("InfoStudent").GetSnapshotAsync()
                .ContinueWith(queryTask =>
                {
                    List<string> mssvs = new List<string>();
                    QuerySnapshot querySnapshot = queryTask.Result;
                    foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                    {
                        string mssv = documentSnapshot.Id;
                        mssvs.Add(mssv);

                    }
                    return mssvs;

                });
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
