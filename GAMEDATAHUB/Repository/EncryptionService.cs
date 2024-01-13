using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GAMEDATAHUB.Repository
{
    public class EncryptionService
    {
        public static string Encrypt(string password, out string salt)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[16];
                rng.GetBytes(saltBytes);

                salt = Convert.ToBase64String(saltBytes);
                string combined = password + salt;

                using (var sha256 = SHA256.Create())
                {
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
                    return Convert.ToBase64String(hashedBytes);
                }
            }
        }

        public static bool Decrypt(string password, string salt, string hashedPassword)
        {
            string combined = password + salt;

            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
                string newHashedPassword = Convert.ToBase64String(hashedBytes);

                return newHashedPassword == hashedPassword;
            }
        }

    }
}