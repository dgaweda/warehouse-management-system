using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.LocationQueries
{
    public class GetLocationsHelper : IGetEntityHelper<Location>
    {
        public string Name { get; set; }
        public DataAccess.Entities.Type LocationType { get; set; }

        public async Task<List<Location>> GetFilteredData(WMSDatabaseContext context)
        {
            var locations = await context.Locations
                .Include(x => x.Product)
                .Where(x => x.Type == LocationType).ToListAsync();
            
            if (PropertiesAreEmpty())
                return locations;
            else
                locations = SearchByName(locations);

            return locations;
        }

        public bool PropertiesAreEmpty() => string.IsNullOrEmpty(Name);
        private List<Location> SearchByName(List<Location> locations) => locations.Where(x => x.Name.Contains(Name)).ToList();
    }
}
