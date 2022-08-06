using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Seeders.Data
{
    public class DummyUser
    {
        public static List<User> GetDummyUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Name = "Adam",
                    Lastname = "Małysz",
                    Age = 25,
                    Email = "malysz@email.com",
                    Username = "malysz",
                    Password = BCrypt.Net.BCrypt.HashPassword("malysz"),
                    PESEL = "94021984158"
                },
                new User()
                {
                    Name = "Clark",
                    Lastname = "Kent",
                    Age = 35,
                    Email = "kent@email.com",
                    Username = "kent",
                    Password = BCrypt.Net.BCrypt.HashPassword("kent"),
                    PESEL = "95021984158"
                },
                new User()
                {
                    Name = "admin",
                    Lastname = "admin",
                    Age = 25,
                    Email = "admin@email.com",
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                    PESEL = "97021984158"
                }
            };
        }

        public static void SetDummyUsers(WMSDatabaseContext context)
        {
            var user1 = context.Users.First();
            var user2 = context.Users.Skip(1).First();
            var user3 = context.Users.Skip(2).First();

            var role1 = context.Roles.First();
            var role2 = context.Roles.Skip(1).First();
            var role3 = context.Roles.Skip(3).First();

            user1.RoleId = role1.Id;
            user2.RoleId = role2.Id;
            user3.RoleId = role3.Id;
        }
    }
}