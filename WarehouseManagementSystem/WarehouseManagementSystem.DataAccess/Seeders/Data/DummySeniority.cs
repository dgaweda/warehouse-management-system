using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seed
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
    }
}