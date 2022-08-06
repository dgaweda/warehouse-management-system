using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Seeders.Data
{
    public static class DummySeniority
    {
        public static List<Seniority> GetDummySeniority()
        {
            return new List<Seniority>()
            {
                new Seniority()
                {
                    EmploymentDate = new DateTime(2020, 09, 15)
                },
                new Seniority()
                {
                    EmploymentDate = new DateTime(2021, 6, 1)
                },
                new Seniority()
                {
                    EmploymentDate = new DateTime(2022, 5, 25)
                }
            };
        }

        public static void SetDummySeniority(WMSDatabaseContext context)
        {
            var seniority1 = context.Seniorities.First();
            var seniority2 = context.Seniorities.Skip(1).First();
            var seniority3 = context.Seniorities.Skip(2).First();

            var user1 = context.Users.First();
            var user2 = context.Users.Skip(1).First();
            var user3 = context.Users.Skip(2).First();

            seniority1.UserId = user1.Id;
            seniority2.UserId = user2.Id;
            seniority3.UserId = user3.Id;
        }
    }
}