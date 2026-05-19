using System.Security.Cryptography;
using System.Text;

namespace SecureEnterpriseApp.Security
{
    public class EncryptionService
    {
        private readonly string key =
            "12345678901234567890123456789012";

        public string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(key);

            aes.GenerateIV();

            var iv = aes.IV;

            using var encryptor =
                aes.CreateEncryptor(aes.Key, iv);

            using MemoryStream ms = new();

            ms.Write(iv, 0, iv.Length);

            using CryptoStream cs =
                new(ms, encryptor, CryptoStreamMode.Write);

            using StreamWriter sw = new(cs);

            sw.Write(plainText);

            sw.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string cipherText)
        {
            var fullCipher =
                Convert.FromBase64String(cipherText);

            using Aes aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(key);

            byte[] iv = new byte[16];

            Array.Copy(fullCipher, iv, iv.Length);

            aes.IV = iv;

            using var decryptor =
                aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream ms =
                new(fullCipher, 16, fullCipher.Length - 16);

            using CryptoStream cs =
                new(ms, decryptor, CryptoStreamMode.Read);

            using StreamReader sr = new(cs);

            return sr.ReadToEnd();
        }
    }
}