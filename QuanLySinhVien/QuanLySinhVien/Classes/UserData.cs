using Google.Cloud.Firestore;

namespace QuanLySinhVien.Classes
{
    [FirestoreData]
    internal class UserData
    {
        [FirestoreProperty]
        public string Username { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
        [FirestoreProperty]
        public string Type { get; set; }
    }
}
