using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Security
    {
        const int keySize = 64;
        const int iterations = 350000;

        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
        public bool VerifyPassword(string password, string storedHashedPassword, byte[] salt)
        {

            var hashBytes = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            string enteredHashedPassword = Convert.ToHexString(hashBytes);

            return storedHashedPassword == enteredHashedPassword;
        }
    }
}
