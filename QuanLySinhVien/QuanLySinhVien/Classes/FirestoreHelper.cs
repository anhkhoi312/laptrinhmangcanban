using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Classes
{
    internal static class FirestoreHelper
    {
        static string fireconfig = @" 
          {
  ""type"": ""service_account"",
  ""project_id"": ""ltmcb-7d1a6"",
  ""private_key_id"": ""e54e63d9d4a5c96006a66c123e1e89a3e5fd9ecf"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDPbi9wUbe4jlqw\ncE2BhEsBZTwmThd7b5lGWCjzuzWwPqs73dOEIgvaUCYVUo+32/9/sD1ZAPcs/4Rv\nXIzWS9Zxl9Z1uv/BXgvJVeGxkepy6vcjFmYMKzwmRvafFAYHdosEBtkBut/MLVdN\nlC8LVSgfDT5rZEZujjfNu46N4BvFSYSq4UUhsaSPJPKS2YKi7IM6Gfg6aiv3p6Gl\nnKCyWLg4celWX1ijGtt9Nxzo/MpmT3R5inEa2KwlIO6JNi58aYE5KlFvQewRjWkp\na0PSoNVR90RdNG+j4qzLagLFU/t/kh+hSuClgSIlvGv2cfQ84RYMsuKxUugdzfhc\nlquauy/zAgMBAAECggEAFig+cACCn/ewz0UHumx/uJPwQ2U3E+vdUwrKwRI/z2Y6\nU0hENkqOupCyKLfreyfIWILiYrX8MTXQFzcrIh7ytqqR8Xx6olSh7K08UQP1p7Xa\nlUhouScLI0mUQXTZmgV7HwB+QLWN/1jeiP5psgu0H/EBuGX7MgcGBfdhaF1GiiG5\nf+9qrBHkQ+g1jLdLvA58KPE8z45+2kkcBdZSqdnc1P9iwSnpZ19L4lSycQLjhi3A\nW0VCxYcXZcs36GXhDvE6XAVYV3cDOcPrSqe7XS6h3W00mLtydUx4um2A3x1W8kz/\nGtnchRiSFYtJVOHlSKVGNZYgfpdHmuQX3uUNG9fhNQKBgQDwlD6KjpO5qu9p28zC\nnBoLs2MIB4W0f58xVoB56PTDmpevu8qVDO9XuaRQnI0QER6hkwUBGa9rZ7ImTcWx\nMRcw/umcLbuZsdvqU5O4FRE+VM4sn9YrEXbSJQrbjYf/LCmDh23m3jqwKno9iYts\naO6nye61DUBCpy1S9F0kNI/XjQKBgQDcuf3auBqYhw0Nz1r9qzWPe0EH+d7WoQJ8\nKMXwxKdhuYuccpGZLLdq6SnH3bsFkhYEgVls52dGvc/+NBjMi54JT79si7poNqhn\n8MYoHKPUM/TRF07BdrkWIfvuWWCnaGtkd5cdng8OIEoHqAF1Gmm5NrRgqit4Kqq2\nFTwR/6+FfwKBgQCD73jA+eIP76turYkErSEni5Bi5eUwkNDX+O1qbhRVdWF8kYtO\n5JIZ1QhE4SYHSqw2xe73pINsbqjnkr05KIfkadfpu7bnWgAV6RHY4Uzclxueo2WL\npv83zfK/Z0XO7gQySsI921/qHtF9EAJzSLShNgAAMK0uIIqdtL+jzGOaPQKBgBYD\nVpXhloVvspWWAHUcBhNxL2MkQF0XYbAQQO1qL2dHoezQYETueLxo1IniSyybDScV\n311FFr+vXnbzqyV7Jx+2nFiu9sA98z2qfZiygoQ/SkMwF+KjfIIAkaeLsl//wfYb\nFy8U/FtkTP3Ge566K6EVG5goYH1zg+L06zDAVzjxAoGAXVbgORiz4BUfSDy5oQwi\nZbXWW48C7pafKK6La+jkELsUqebi9Sdt5RCVErfKSLAbhLCa8Eqn0RAo+ddwGW/G\nsRwU56kx0eDUtkItwgjz6cSzBaf2DYRAc0H/U6OMax2/lB7oFnowe/l1+QU0YFv/\nfg7wGXs4uVP3OeRYhzqvFAE=\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""firebase-adminsdk-c4yeo@ltmcb-7d1a6.iam.gserviceaccount.com"",
  ""client_id"": ""107838193346680894495"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-c4yeo%40ltmcb-7d1a6.iam.gserviceaccount.com"",
  ""universe_domain"": ""googleapis.com""
}



";
        static string filepath = "";
        public static FirestoreDb database { get; private set; }
        public static void SetEnvironmentVariable()
        {
            filepath = Path.Combine(Path.GetTempPath(),Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + "json";
            File.WriteAllText(filepath, fireconfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            database = FirestoreDb.Create("ltmcb-7d1a6");
            File.Delete(filepath);
        }
    }
}
