using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.DummyData
{
    public class DummyRoles
    {
        public IEnumerable<Role> CreateDummyRoles()
        {
            return new[]
            {
                new Role()
                {
                    Id = new Guid(),
                    Description = "Collect orders",
                    Name = "collector",
                    Rank = 1,
                    Salary = 3000
                },
                new Role()
                {
                    Id = new Guid(),
                    Description = "sending pallets, getting departures, placing pallets, delivery service",
                    Name = "warehouseman",
                    Rank = 2,
                    Salary = 3500
                },
                new Role()
                {
                    Id = new Guid(),
                    Description = "Manage other workers",
                    Name = "manager",
                    Rank = 3,
                    Salary = 4000
                },
                new Role()
                {
                    Id = new Guid(),
                    Description = "System administrator",
                    Name = "admin",
                    Rank = 4,
                    Salary = 5000
                }
            };
        }
    }
}