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
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public async Task<List<Seniority>> GetFilteredData(WMSDatabaseContext context)
        {
            var seniorities = await context.Seniorities
                .Include(x => x.User)
                .ToListAsync();

            if (PropertiesAreEmpty())
                return seniorities;

            if (!string.IsNullOrEmpty(UserFirstName))
                seniorities = SearchByUserFirstName(seniorities);

            if (!string.IsNullOrEmpty(UserLastName))
                seniorities = SearchByUserLastName(seniorities);

            if (EmploymentDate > DateTime.MinValue)
                seniorities = SearchByEmploymentDate(seniorities);

            return seniorities;
        }

        private List<Seniority> SearchByUserFirstName(List<Seniority> seniorities) => seniorities.Where(seniority => seniority.User.Name == UserFirstName).ToList();

        private List<Seniority> SearchByUserLastName(List<Seniority> seniorities) => seniorities.Where(seniority => seniority.User.LastName == UserLastName).ToList();

        private List<Seniority> SearchByEmploymentDate(List<Seniority> seniorities) => seniorities.Where(seniority => seniority.EmploymentDate > EmploymentDate).ToList();
        public bool PropertiesAreEmpty() => string.IsNullOrEmpty(UserFirstName) && string.IsNullOrEmpty(UserLastName) && EmploymentDate == DateTime.MinValue;
    }
}
