using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using DataAccess.Entities;
using DataAccess.Migrations;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DataAccess.CQRS.Helpers
{
    public static class UserHelper
    {
        public static List<User> FilterByUserId(this List<User> users, int userId)
        {
            return userId == default ? users : users.Where(user => user.Id == userId).ToList();
        }

        public static List<User> FilterByRoleName(this List<User> users, string roleName)
        {
            return string.IsNullOrEmpty(roleName) ? users : users.Where(user => user.Role.Name.Contains(roleName)).ToList();
        }

        public static List<User> FilterByPESEL(this List<User> users, string pesel)
        {
            return string.IsNullOrEmpty(pesel) ? users : users.Where(user => user.PESEL == pesel).ToList();
        }

        public static List<User> FilterByAge(this List<User> users, int age)
        {
            return age == default ? users : users.Where(user => user.Age == age).ToList();
        }

        public static List<User> FilterByName(this List<User> users, string name)
        {
            return string.IsNullOrEmpty(name) ? users : users.Where(user => user.Name.Contains(name)).ToList();
        }
        
        public static List<User> FilterByLastName(this List<User> users, string lastName)
        {
            return string.IsNullOrEmpty(lastName) ? users : users.Where(user => user.LastName.Contains(lastName)).ToList();
        }
        
        public static bool HasCorrectPassword(this User user, string password)
        {
            var passwordData = user.HashPassword(password);
            return user.Password.Equals(passwordData.Password);
        }

        public static (string Password, byte[] saltBytes) HashPassword(this User user, string password)
        {
            var saltBytes = new byte[128 / 8];
            if (string.IsNullOrEmpty(user.Salt))
            {
                RandomNumberGenerator.Create().GetBytes(saltBytes); // Fill saltBytes Array by random numbers
            }
            else
            {
                saltBytes = Convert.FromBase64String(user.Salt);
            }

            password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)
            );

            return (password, saltBytes);
        }
    }
}
