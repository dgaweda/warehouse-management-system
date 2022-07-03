using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Extensions;
using DataAccess.Repository.DepartureRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.DepartureQueries
{
    public class GetDeparturesQuery : QueryBase<List<Departure>, IDepartureRepository>
    {
        public string Name { get; set; }
        public DateTime OpeningTime { get; set; }

        public override async Task<List<Departure>> Execute(IDepartureRepository departureRepository)
        {
            var departures = await departureRepository.GetAllAsync();

            return departures
                .FilterByName(Name)
                .FilterByOpeningTime(OpeningTime);
        }
    }
}
