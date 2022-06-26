using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.CQRS.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.DepartureQueries
{
    public class GetDeparturesQuery : QueryBase<List<Departure>>
    {
        public string Name { get; set; }
        public DateTime OpeningTime { get; set; }
        public StateType? State { get; set; }

        public override async Task<List<Departure>> Execute(WMSDatabaseContext context)
        {
            var departures = await context.Departures
                .Where(departure => departure.State == State)
                .ToListAsync();

            return departures
                .FilterByName(Name)
                .FilterByOpeningTime(OpeningTime);
        }
    }
}
