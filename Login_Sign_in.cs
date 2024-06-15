using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
namespace Library_management_system
{
    internal class Login_Sign_in
    {
        public static string DecryptString(string cipherText)
        {
            byte[] key = new byte[16];
            byte[] iv = new byte[16];
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        public static string MD5encipher(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] passwordByte = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] passwordHash = md5.ComputeHash(passwordByte);
                string s = "";
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    s += passwordHash[i].ToString("X2");
                }
                return s;
            }
        }
        public async static Task<bool> Pingtest()
        {
            try
            {
                Ping ping = new Ping();
                int timeout = 3000;
                PingReply reply = await ping.SendPingAsync($"{DecryptString(GetJsonObject().PingIp)}", timeout);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                return false;
            }
            catch (PingException)
            {
                return false;
            }
        }
        public static jsonClass GetJsonObject()
        {
            try
            {
                string json = File.ReadAllText("Lmsconfig.json");
                jsonClass jObect = JsonConvert.DeserializeObject<jsonClass>(json);
                return jObect;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
                return new jsonClass();
            }
        }
        public class jsonClass
        {
            public string? DataSource { get; set; }
            public string? InitialCatalog { get; set; }
            public string? UserID { get; set; }
            public string? Password { get; set; }
            public string? PingIp { get; set; }

            public string? SendEmail { get; set; }
        }
    }

}
