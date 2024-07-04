using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySinhVien.Classes
{
    public class FirebaseService
    {
        private FirebaseClient firebaseClient;
        public FirebaseService()
        {
            firebaseClient = new FirebaseClient("https://ltmcb-7d1a6-default-rtdb.firebaseio.com/");
        }
        public async Task CreateUserAsync(string userId, string name, string role)
        {
            var user = new { name = name, role = role };
            await firebaseClient.Child("users").Child(userId).PutAsync(user);
        }
        public async Task<string> CreateConversationAsync(string userId1, string userId2)
        {
            string conversationId = $"{userId1}_{userId2}";
            var conversation = new { participants = new[] { userId1, userId2 } };
            await firebaseClient.Child("conversations").Child(conversationId).PutAsync(conversation);
            return conversationId;
        }
        public async Task SendMessageAsync(string conversationId, string senderId, string messageContent)
        {
            var message = new { sender = senderId, content = messageContent, timestamp = DateTime.UtcNow.ToString("o") };
            await firebaseClient.Child("conversations").Child(conversationId).Child("messages").PostAsync(message);
        }
        public async Task<List<dynamic>> RetrieveMessagesAsync(string conversationId)
        {
            var messages = await firebaseClient.Child("conversations").Child(conversationId).Child("messages").OrderBy("timestamp").OnceAsync<dynamic>();
            return messages.Select(m => m.Object).ToList();
        }
    }
}
