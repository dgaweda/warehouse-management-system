using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using DataAccess.Entities;

namespace DataAccess.Extensions
{
    public static class UserExtension
    {
        public static IQueryable<User> FilterByUserId(this IQueryable<User> users, Guid userId)
        {
            return userId == default ? users : users.Where(user => user.Id == userId);
        }

        public static IQueryable<User> FilterByRoleName(this IQueryable<User> users, string roleName)
        {
            return string.IsNullOrEmpty(roleName) ? users : users.Where(user => user.Role.Name.Contains(roleName));
        }

        public static IQueryable<User> FilterByPesel(this IQueryable<User> users, string pesel)
        {
            return string.IsNullOrEmpty(pesel) ? users : users.Where(user => user.PESEL == pesel);
        }

        public static IQueryable<User> FilterByAge(this IQueryable<User> users, int age)
        {
            return age == default ? users : users.Where(user => user.Age == age);
        }

        public static IQueryable<User> FilterByName(this IQueryable<User> users, string name)
        {
            return string.IsNullOrEmpty(name) ? users : users.Where(user => user.Name.Contains(name));
        }
        
        public static IQueryable<User> FilterByLastName(this IQueryable<User> users, string lastName)
        {
            return string.IsNullOrEmpty(lastName) ? users : users.Where(user => user.LastName.Contains(lastName));
        }

        public static User VerifyPassword(this User user, string password)
        {
            var hasCorrectPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (!hasCorrectPassword)
                throw new AuthenticationException("Password is incorrect.");

            return user;
        }
    }
}
