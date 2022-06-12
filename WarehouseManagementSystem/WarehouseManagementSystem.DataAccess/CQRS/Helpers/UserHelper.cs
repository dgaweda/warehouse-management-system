using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

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
    }
}
