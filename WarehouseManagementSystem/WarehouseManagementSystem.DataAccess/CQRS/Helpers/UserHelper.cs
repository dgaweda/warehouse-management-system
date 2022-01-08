using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DataAccess.CQRS.Helpers
{
    public static class UserHelper
    {
        public static void HashPassword(this User user)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            SetUserData(user, hashedPassword, salt);
        }

        public static void SetUserData(User user, string password, byte[] salt)
        {
            var saltString = Convert.ToBase64String(salt);

            user.Password = password;
            user.Salt = saltString;
        }
    }
}
