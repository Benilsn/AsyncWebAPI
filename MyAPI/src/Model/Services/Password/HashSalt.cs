using System;
using System.Security.Cryptography;

namespace MyAPI.src.Model.Services.Password
{
    public class HashSalt
    {

        internal string Hash { get; set; }
        internal string Salt { get; set; }


        public static HashSalt GenerateSaltedHash(string password)
        {

            byte[] saltBytes = new byte[128 / 8];

            // Fill the array with nonzero values;
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(saltBytes);
            }

            // Converts the bits array to its equivalent string representation;
            var salt = Convert.ToBase64String(saltBytes);


            // Generate de hash of the string using the RFC2898 specification, which uses a method known as PBKDF2.
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);


            var hashedPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));


            HashSalt hashSalt = new HashSalt
            {
                Hash = hashedPassword,
                Salt = salt
            };

            return hashSalt;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
    }
}
