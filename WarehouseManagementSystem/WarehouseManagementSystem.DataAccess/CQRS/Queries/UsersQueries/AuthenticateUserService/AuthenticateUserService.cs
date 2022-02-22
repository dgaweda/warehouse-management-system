using System;
using System.Security.Cryptography;
using DataAccess.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DataAccess.CQRS.Queries.UsersQueries
{
    public class AuthenticateUserService : IAuthenticateUserService
    {
        public bool HasCorrectPassword(User user, string password)
        {
            var passwordData = HashPassword(password, user);
            return user.Password.Equals(passwordData.Password);
        }

        public (string Password, byte[] SaltBytes) HashPassword(string password, User user)
        {
            var saltBytes = new byte[128 / 8];
            if (string.IsNullOrEmpty(user.Salt))
            {
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(saltBytes);
                }
            }
            else
            {
                saltBytes = Convert.FromBase64String(user.Salt);
            }
            
            password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return (password, saltBytes);
        }

        public void SetData(User user, string password, byte[] salt)
        {
            throw new NotImplementedException();
        }
    }
}