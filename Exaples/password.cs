using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Exaples
{
    public class password
    {
        private static readonly byte[] initVectorBytes = Encoding.UTF8.GetBytes("1234567890abcdef"); // must be same as encryption
        private static readonly int keysize = 128;

        public void Run()
        {
            string plainText = "Hello World!";
            try
            {
                byte[] cipherTextBytes = Convert.FromBase64String("20jMZxS58YhWIU2708qqyA==");

                using (PasswordDeriveBytes password = new PasswordDeriveBytes("r0b1nr0y", null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Result: {ex.Message}");
            }

            Console.WriteLine($"Result: {plainText}");
        }
    }
}
