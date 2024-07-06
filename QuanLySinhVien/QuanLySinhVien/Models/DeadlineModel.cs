using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;



namespace QuanLySinhVien.Models
{
    public class CreateDeadlineModel
    {
        public string Title { get; set; }
        public DateTime DeadlineDate { get; set; }
        public string ClassID { get; set; }
    }

    [FirestoreData]
    public class DeadlineModel
    {
        public string Id { get; set; }
        [FirestoreProperty]
        public string Title { get; set; }

        [FirestoreProperty]
        public DateTime DeadlineDate { get; set; }

        [FirestoreProperty]
        public string ClassID { get; set; }

        [FirestoreProperty]
        public string FileUrl { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }



    [FirestoreData]
    public class SubmissionModel
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string StudentId { get; set; }

        [FirestoreProperty]
        public string AssignmentId { get; set; }

        [FirestoreProperty]
        public string FileUrl { get; set; }

        [FirestoreProperty]
        public DateTime SubmittedDate { get; set; }

        public override string ToString()
        {
            return StudentId; // Hiển thị mã số sinh viên
        }
    }
}
