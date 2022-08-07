using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seeders.Data
{
    public static class DummyRoles
    {
        public static List<Role> GetDummyRoles()
        {
            return new List<Role>()
            {
                new Role()
                {
                    Description = "Collect orders",
                    Name = "collector",
                    Rank = 1,
                    Salary = 3000
                },
                new Role()
                {
                    Description = "sending pallets, getting departures, placing pallets, delivery service",
                    Name = "warehouseman",
                    Rank = 2,
                    Salary = 3500
                },
                new Role()
                {
                    Description = "Manage other workers",
                    Name = "manager",
                    Rank = 3,
                    Salary = 4000
                },
                new Role()
                {
                    Description = "System administrator",
                    Name = "admin",
                    Rank = 4,
                    Salary = 5000
                }
            };
        }
    }
}