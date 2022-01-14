using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.LocationQueries
{
    public class GetLocationsQuery : QueryBase<List<Location>>
    {
        public string Name { get; set; }
        public DataAccess.Entities.Type LocationType { get; set; }

        public override async Task<List<Location>> Execute(WMSDatabaseContext context)
        {
            var locations = await context.Locations
                .Include(x => x.Product)
                .Where(x => x.Type == LocationType)
                .ToListAsync();
            
            return locations.FilterByName(Name);
        }
    }
}
