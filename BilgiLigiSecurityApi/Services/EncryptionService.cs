using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BilgiLigiSecurityApi.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string AESEncryptText(string input, string password)
        {
            // convert both input string and key into bytes array
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // convert key to sha hash and then pass for encryption
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            // pass those array and password hash for decryption
            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            // converted encrypted text to base 64 string
            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public string AESDecryptText(string input, string password)
        {
            try
            {
                // convert both encrypted string and key into bytes array
                byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // convert key to sha hash and then pass for encryption
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                // pass those array and password hash for decryption
                byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

                // converted encrypted text to base 64 string
                string result = Encoding.UTF8.GetString(bytesDecrypted);

                return result;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                // object for Rijindael class is created
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    // Set Block and Key size 
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    // convert those key with the help of salt for encryption
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    // encrypt data, by using above key and its attributes by using  AES.CreateEncryptor() method
                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }


        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    // Set Block and Key size 
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;
                    // decrypt data, by using above key and its attributes by using  AES.CreateEncryptor() method
                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public string ComputeSha256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
