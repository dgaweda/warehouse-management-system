using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seed
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
    }
}