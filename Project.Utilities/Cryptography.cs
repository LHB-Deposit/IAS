using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Project.Utilities
{
    public class Cryptography
    {
        private const string PassPhrase = "LHBank@2020!";
        public static string EncryptString(string plainText)
        {
            var bToEncrypt = Encoding.UTF8.GetBytes(plainText);
            var bPassPhrase = Encoding.UTF8.GetBytes(PassPhrase);

            bPassPhrase = SHA512.Create().ComputeHash(bPassPhrase);
            var bEncrypted = Encrypt(bToEncrypt, bPassPhrase);
            return Convert.ToBase64String(bEncrypted);
        }

        public static string DecryptString(string encryptText)
        {
            var bToDecrypt = Convert.FromBase64String(encryptText);
            var bPassPhrase = Encoding.UTF8.GetBytes(PassPhrase);

            bPassPhrase = SHA512.Create().ComputeHash(bPassPhrase);
            var bDecrypt = Decrypt(bToDecrypt, bPassPhrase);
            return Encoding.UTF8.GetString(bDecrypt);
        }

        private static byte[] Encrypt(byte[] bToEncrypt, byte[] bPassPhrase)
        {
            byte[] bEncrypted = null;

            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using(MemoryStream memoryStream = new MemoryStream())
            {
                using(RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(bPassPhrase, saltBytes, 1000);
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;
                    using(var cs = new CryptoStream(memoryStream, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bToEncrypt, 0, bToEncrypt.Length);
                        cs.Close();
                    }
                    bEncrypted = memoryStream.ToArray();
                }
            }

            return bEncrypted;
        }
        private static byte[] Decrypt(byte[] bToDecrypt, byte[] bPassPhrase)
        {
            byte[] bDecrypt = null;

            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using(RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(bPassPhrase, saltBytes, 1000);
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;
                    using(var cs = new CryptoStream(memoryStream, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bToDecrypt, 0, bToDecrypt.Length);
                        cs.Close();
                    }
                    bDecrypt = memoryStream.ToArray();
                }
            }

            return bDecrypt;
        }
    }
}
