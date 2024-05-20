using QuanLySinhVien.Classes;
using QuanLySinhVien.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLySinhVien
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static async Task Main()
        {   // chỗ này khi nào cập nhật database mới thì mới mở lên
            //await InitializeUsersAndConversations();


            FirestoreHelper.SetEnvironmentVariable();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
        }
        public static async Task InitializeUsersAndConversations()
        {
            FirebaseService firebaseService = new FirebaseService();

            await firebaseService.CreateUserAsync("22520701", "Phan Trần Anh Khôi", "student");
            await firebaseService.CreateUserAsync("22520718", "Huynh Ngoc Anh Kiet", "student");
            await firebaseService.CreateUserAsync("22520897", "Ho Thi Huynh My", "student");
            await firebaseService.CreateUserAsync("22520937", "Tran Thu Ngan", "student");
            await firebaseService.CreateUserAsync("22521003", "Nguyen Thanh Nhan", "student");
            await firebaseService.CreateUserAsync("22521068", "Lam Thien Phat", "student");
            await firebaseService.CreateUserAsync("22521106", "Tran Hoai Phu", "student");
            await firebaseService.CreateUserAsync("22521125", "Nguyen Duong Hoang Phuc", "student");
            await firebaseService.CreateUserAsync("GV001", "Dinh Manh Hung", "teacher");
            // await firebaseService.CreateUserAsync("002", "Teacher 002", "teacher");
            // await firebaseService.CreateUserAsync("003", "Teacher 003", "teacher");

            //await firebaseService.CreateConversationAsync("22520701", "001");
            //await firebaseService.CreateConversationAsync("22520701", "002");
            //await firebaseService.CreateConversationAsync("22521213", "001");
            //await firebaseService.CreateConversationAsync("22521213", "003");

            await firebaseService.CreateConversationAsync("22520701", "GV001");
            await firebaseService.CreateConversationAsync("22520718", "GV001");
            await firebaseService.CreateConversationAsync("22520897", "GV001");
            await firebaseService.CreateConversationAsync("22520937", "GV001");
            await firebaseService.CreateConversationAsync("22521003", "GV001");
            await firebaseService.CreateConversationAsync("22521068", "GV001");
            await firebaseService.CreateConversationAsync("22521106", "GV001");
            await firebaseService.CreateConversationAsync("22521125", "GV001");
        }
    }
}