﻿using System.Security.Cryptography;
namespace Library_management_system
{
    internal class En_and_De
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
        public static string EncryptString(string plainText)
        {
            byte[] key = new byte[16];
            byte[] iv = new byte[16];
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
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
    }
}
