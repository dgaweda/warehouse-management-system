﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static List<User> FilterByUserId(this List<User> users, int userId)
        {
            if (userId == default)
                return users;

            return users.Where(user => user.Id == userId).ToList();
        }

        public static List<User> FilterByRoleName(this List<User> users, string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return users;

            return users.Where(user => user.Role.Name.Contains(roleName)).ToList();
        }

        public static List<User> FilterByPESEL(this List<User> users, string pesel)
        {
            if (string.IsNullOrEmpty(pesel))
                return users;

            return users.Where(user => user.PESEL == pesel).ToList();
        }

        public static List<User> FilterByAge(this List<User> users, int age)
        {
            if (age == default)
                return users;

            return users.Where(user => user.Age == age).ToList();
        }

        public static List<User> FilterByName(this List<User> users, string name)
        {
            if (string.IsNullOrEmpty(name))
                return users;

            return users.Where(user => user.Name.Contains(name)).ToList();
        }
        public static List<User> FilterByLastName(this List<User> users, string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                return users;

            return users.Where(user => user.LastName.Contains(lastName)).ToList();
        }
    }
}