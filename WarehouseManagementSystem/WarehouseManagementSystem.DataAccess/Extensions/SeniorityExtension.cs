using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Extensions
{
    public static class SeniorityExtension
    {
        public static List<Seniority> FilterByUserFirstName(this List<Seniority> seniorities, string userFirstName)
        {
            if (string.IsNullOrEmpty(userFirstName))
                return seniorities;

            return seniorities.Where(seniority => seniority.User.Name == userFirstName).ToList();
        }

        public static List<Seniority> FilterByUserLastName(this List<Seniority> seniorities, string userLastName)
        {
            if (string.IsNullOrEmpty(userLastName))
                return seniorities;

            return seniorities.Where(seniority => seniority.User.LastName == userLastName).ToList();
        }

        public static List<Seniority> FilterByEmploymentDate(this List<Seniority> seniorities, DateTime employmentDate)
        {
            if (employmentDate == default)
                return seniorities;

            return seniorities.Where(seniority => seniority.EmploymentDate > employmentDate).ToList();
        }
    }
}
