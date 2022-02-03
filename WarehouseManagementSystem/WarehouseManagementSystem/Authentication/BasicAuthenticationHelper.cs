using System;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.CQRS.Queries.UsersQueries;
using DataAccess.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace warehouse_management_system.Authentication
{
    public static class BasicAuthenticationHelper
    {
        public static bool HasCorrectPassword(this User user, string password)
        {
            var hashedPassword = password.Hash(user);
            return user.Password.Equals(hashedPassword);
        }

        public static async Task<User> GetUser(IQueryExecutor queryExecutor, GetUserQuery query)
        { 
            return await queryExecutor.Execute(query);
        }

        private static string Hash(this string password, User user)
        {
            var saltBytes = Convert.FromBase64String(user.Salt);
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
