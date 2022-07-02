﻿using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Queries.LocationQueries
{
    public class GetLocationsQuery : QueryBase<List<Location>>
    {
        public string Name { get; set; }
        public LocationType LocationType { get; set; }

        public override async Task<List<Location>> Execute(WMSDatabaseContext context)
        {
            var locations = await context.Locations
                .Include(x => x.Product)
                .Where(x => x.LocationType == LocationType)
                .ToListAsync();
            
            var result = locations.FilterByName(Name);
            if (!result.Any())
                throw new NotFoundException("Location doesn't exist");

            return result;
        }
    }
}
