using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.SeniorityQueries
{
    public class GetSenioritiesHelper : IGetEntityHelper<Seniority>
    {
        public DateTime EmploymentDate { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }

        public async Task<List<Seniority>> GetFilteredData(WMSDatabaseContext context)
        {
            var seniorities = await context.Seniorities
                .Include(x => x.Employee)
                .ToListAsync();

            if (PropertiesAreEmpty())
                return seniorities;

            if (!string.IsNullOrEmpty(EmployeeName))
                seniorities = SearchByEmployeeName(seniorities);

            if (!string.IsNullOrEmpty(EmployeeLastName))
                seniorities = SearchByEmployeeLastName(seniorities);

            if (EmploymentDate > DateTime.MinValue)
                seniorities = SearchByEmploymentDate(seniorities);

            return seniorities;
        }

        private List<Seniority> SearchByEmployeeName(List<Seniority> seniorities) => seniorities.Where(seniority => seniority.Employee.Name == EmployeeName).ToList();

        private List<Seniority> SearchByEmployeeLastName(List<Seniority> seniorities) => seniorities.Where(seniority => seniority.Employee.LastName == EmployeeLastName).ToList();

        private List<Seniority> SearchByEmploymentDate(List<Seniority> seniorities) => seniorities.Where(seniority => seniority.EmploymentDate > EmploymentDate).ToList();
        public bool PropertiesAreEmpty() => string.IsNullOrEmpty(EmployeeName) && string.IsNullOrEmpty(EmployeeLastName) && EmploymentDate == DateTime.MinValue;
    }
}
