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
  ""project_id"": ""database-list-a65df"",
  ""private_key_id"": ""7b0abbaeba5ceff8be7ab9ef6eff0dae2115b896"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCs3oCJapsV70DV\nrPGrOedWyVNKBCXRghIYljOozHV2OyzP0xThIVPhyNaRAado4nkuyDPigkz3mbyp\nuMYdnQXj8AvuAroSLFq4Y2KUyxMDIrkTj156GVfopXQfbX/HdYzrPzM0LNHIyvlb\nzegTg2bt16BeX2V2UZe7ae9abYkr0xacQVg6x74mBH2xyaypsgXwoEOhQRJOkveu\nGXRcNaj1LqN5BPExv1ltX4m9b3fnzCeUcapQVE5SRdjEEqaLfCYb7pU4c0BsTtJE\nghC95YFYxkSG4AZTluCzVzK5OT6ZfUQrIHX6/4T4l/EmS6uIu2idnyAcALU1s4PN\n7yegjKUfAgMBAAECggEAOPXl36GvcVZRBDdEuFlPh3K2DYT5WyPjR5OyePPJ3ofY\nF7CjSB09sP+G5+fmHDLHoGkaY4/wwYM4PapjKV3Uk4tEuwvN+PABgpFI6eNSI+3c\nkvviMxRHuaJO9Y4UlQoAQYGlIxODmoh7Cst5pXheQY+TyZTgb1CqUPgyhJbkJHqS\nWWkJBSkn9hnrEoFOvQ/0fST17XKdBOVo68k0I4DJBIB0LIdDsk+eHngOp7E2oFtI\n/QKyY8VS3GUNx4m8Gs0tTpqzH2GWaLTO37U3gwo8oMocQP6VJZC3EXjk9Lo5E09y\ns6Clrx2/GgLpudGmOJrWZPubDYn6Wla9uAk8GX8v1QKBgQDZmpoTXZ8eeDQEJZQb\nsvCdP79KpfXn4eKLN4pKhF2gC8H9P+f8vV37E23rykF1F+M6hLzTap3scEycHwKT\nbmOQO1Gp0w9RKJ+2Al+VND3/T+G8qQZZ+rq2nru3+cvKSGcbMnKXPH9kxbOFT9ea\nSTw7qS4i3xUI1zkuRHI/ImR8JQKBgQDLXy8LLP/IQtTdbos6BxngFIUDdNvg5opP\n/ENOFkK7/PMg/gqACHAidybx1P+wstS3HkGNUIQv8QS3XYS7Fz+NFvAVrO0UhtVX\nZWttzQE8R8Ym8J/ZdADdj56uX9DfI/2ICmdsvRi1DSn6FOBuqVGO3cllf/WjfGqN\n+xHqlp828wKBgGErUVwOdWx0vr2PTkjkKd/+RFyAKYPncXM7VOybmPdL6M8+x0gs\nA5iHf5FIGty/0v8hoPRDasvXBc69ZjgRljIk2v2buv5BxrfO7YHB92FX+XR2gdiS\nRugfj7HCwQbOOASEDXmNUVHdmqGQGrXRuCzoCisWNN1ixizr8ZxRrk9lAoGAHDOW\n0nXrAlpCKnKp2+IgNHKj/1a1JvrRM0ZIDwwHNQperLSNwDNrWVwsilx/GIGz/bC0\nZmRD8GH7xXGydj9DEM2dfWP9fFs2OmhV/WPwR+usDrpPcFglxpOj7Ypb7JWREsxe\nizWtt22b5JIAjVftd2JKC0kzRvh5zjaCxYUdjwECgYEAxQS4kf4K+RyX1w7tZNDY\nCqyIm1myBpOiPhbpMx+tAtTZzR0aafPJAsPjhNHO/QQOmIIQma1GqxJu5RL4ReSp\ne+vGAVtW9VLz1EP1a/NGx6le5izC7l23CB9tA74zESNu52AMYFy0iEj6oC+Iek2B\n0Sh4uh5CZ81LT8fcq2j6rXQ=\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""firebase-adminsdk-mobgb@database-list-a65df.iam.gserviceaccount.com"",
  ""client_id"": ""111523743590171203772"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-mobgb%40database-list-a65df.iam.gserviceaccount.com"",
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
            database = FirestoreDb.Create("database-list-a65df");
            File.Delete(filepath);
        }
    }
}
