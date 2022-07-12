using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.SeniorityRepository;

namespace DataAccess.CQRS.Query.Queries.SeniorityQueries
{
    public class GetSenioritiesQuery : QueryBase<List<Seniority>, ISeniorityRepository>
    {
        public DateTime EmploymentDate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public override async Task<List<Seniority>> Execute(ISeniorityRepository seniorityRepository)
        {
            var seniority = await seniorityRepository.GetAllAsync();

            return seniority
                .FilterByUserFirstName(UserFirstName)
                .FilterByUserLastName(UserLastName)
                .FilterByEmploymentDate(EmploymentDate);
        }
    }
}
