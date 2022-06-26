using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.SeniorityQueries
{
    public class GetSenioritiesQuery : QueryBase<List<Seniority>>
    {
        public DateTime EmploymentDate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public override async Task<List<Seniority>> Execute(WMSDatabaseContext context)
        { 
            var seniorities = await context.Seniorities
                .Include(x => x.User)
                .ToListAsync();

            return seniorities
                .FilterByUserFirstName(UserFirstName)
                .FilterByUserLastName(UserLastName)
                .FilterByEmploymentDate(EmploymentDate);
        }
    }
}
