using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Extensions
{
    public static class SeniorityExtension
    {
        public static IQueryable<Seniority> FilterByUserFirstName(this IQueryable<Seniority> seniorities, string userFirstName)
        {
            if (string.IsNullOrEmpty(userFirstName))
                return seniorities;

            return seniorities.Where(seniority => seniority.User.Name == userFirstName);
        }

        public static IQueryable<Seniority> FilterByUserLastName(this IQueryable<Seniority> seniorities, string userLastName)
        {
            if (string.IsNullOrEmpty(userLastName))
                return seniorities;

            return seniorities.Where(seniority => seniority.User.Lastname == userLastName);
        }

        public static IQueryable<Seniority> FilterByEmploymentDate(this IQueryable<Seniority> seniorities, DateTime employmentDate)
        {
            if (employmentDate == default)
                return seniorities;

            return seniorities.Where(seniority => seniority.EmploymentDate > employmentDate);
        }
    }
}
