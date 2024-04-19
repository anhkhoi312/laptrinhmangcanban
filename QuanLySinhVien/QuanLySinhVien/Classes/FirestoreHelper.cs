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
  ""private_key_id"": ""b0595ad7361eb2215b695e844fa8861e1200ed37"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQC2vmFujBoK8zhi\npzgnWPlIl0YAaKKVYwHrv+CAGWdGAbiwdCiy3mpL+wbWBP3SjyfR1vWwaFORMOib\nxEhsSQ94MpARdvobGPcbu059DRisOrK41fmIFL9BIsLHFiF+GJFzE5JR1h3cVaaU\n98kPk7+t+gNQhr+BKwzojjX66oHGkYQYMPRlctGuQyB9VtWIPYb/hQmmikBKaRdz\nmSdbOtGF4LP4Nrj7wfObk9L/4LF5oC0hmzalXkyicJ5b9v6d6ulDpMRXor9ECcqh\nzk3qQHA75hAeWh6VmtIiyd7yhC4d3S2jBIm7+j+4NObG6I85H+iNf21BSAue/y5U\nc/bOwCenAgMBAAECggEAH8+/ZT+VTv+s+ptyboMSDh1rTanpV4j/LhteSN5jOHAX\nRvxJk22dYnGl7H688rkB7Qj3Bwj6NyWk8Gy4UMVdIIboxmmIO0xaw+SU0rcDawPi\n1cNF53b5Hi0fbAnBtdIwC7DGAWH9G7x7PaZuxTvqm64QgqWaU7F7U0ZiRjYpdjfV\nkVm6298tWKvxBHKgL2ULIxU1/kRhpK6vlmYLlCpUTxHouufxr95Mf3KUrBrHZE47\nPP9m5FbrF4taXSmyWOPTohVqHN2+/hPRzOd/MUpIfGTmRrETG0rc4eXnf4W+EC7c\nT373d06UHL/j7i7Kw+B7k6pyq/DuBos2VV8IC6agoQKBgQD5D6clf92v1H4Q6n08\nzU4XgT5XVECE4wN2PmWQtEOvTGyOuoE0Umhjr+bgvtMv//+Un1XhhI2sUXU3SUlf\nSjiORl/oQBy43ajryHtXlEv1q5+7Kj9HepIwjE9O6OBUnBXenD0TJsCpAFy/yeGt\n+s4BF4+j48uh7qpPYxwgPNgXhwKBgQC71b1yoohkmZ7JQyF6b8IVsvqAeQhP3JF1\nhDJMeVkdrsXz7GJ9hM6+aNdAzJIlKzAHB28yGyc7kHEiD2lzgxW3c/Mv5ZOaoJzm\nDuQ4uj+cZfIDDxGzYpI8qSRUkEslDQcr4NyOnt92cWJxPR677yMNO+4kFDgTCiPS\nMf58fns24QKBgAg9NFJRQIwog2Mb3ri8MfElHWLWLqw2tk6bEdEPpY2PAahXEx8f\n+sQRdZnJtkLIPTQ1cSncsLManr4NdpfoZKaQPWv5cvnKm2PxZeMnzLt7yfTvGNjM\nfTmN6rG5knI6F58dnAeeKJFuqaLOkuCmg1oV5XKOfpYExy2JIc0PNjbRAoGBAKZg\nYthhgzKop+9Z2ROcXmveBuk5S9WBaA6RtAPtELSsFIdFANBxjLc4IkIxcdoecQIo\n4aOeTZgDD1K+GAfLOrcuq1/nmGDEl3VoB1sADkw4OK/g7yrXyvSUVavZy9Xbvlht\naq+hpgpB0JLBMrIA1iloxj2K80haGPScd/BKEFXBAoGBALtaIZ7D48v1f/iqbTkf\nTXVewn/SlZHACc0bpmg0ivjJopLY9ja2MW4QrULuzz0E1Mjiiz0pyVN3xJzGe6wI\nFH4XsM4nqGTKb9QoYbsupfHYDWwnISSGoIkHML47rtqEEhXe59sJK5kmY3SxdAHq\nJcKqnBcfYrGPjEN5n0nSKZ1C\n-----END PRIVATE KEY-----\n"",
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
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTUALS", filepath);
            database = FirestoreDb.Create("database-list-a65df");
            File.Delete(filepath);
        }
    }
}
