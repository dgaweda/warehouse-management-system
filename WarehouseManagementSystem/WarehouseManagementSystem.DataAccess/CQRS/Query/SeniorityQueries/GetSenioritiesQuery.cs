using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.SeniorityRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Query.Queries.SeniorityQueries
{
    public class GetSenioritiesQuery : QueryBase<List<Seniority>>
    {
        private readonly ISeniorityRepository _seniorityRepository;

        public GetSenioritiesQuery(ISeniorityRepository seniorityRepository)
        {
            _seniorityRepository = seniorityRepository;
        }

        public DateTime EmploymentDate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public override async Task<List<Seniority>> Execute()
        {
            return await _seniorityRepository.GetAll()
                .FilterByUserFirstName(UserFirstName)
                .FilterByUserLastName(UserLastName)
                .FilterByEmploymentDate(EmploymentDate)
                .ToListAsync();
        }
    }
}
