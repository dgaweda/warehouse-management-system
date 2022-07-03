using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Repository.LocationRepository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Location>> GetAllAsync()
        {
            return await GetLocations().ToListAsync();
        }

        public async Task<List<Location>> GetLocationsByType(LocationType locationType)
        {
            return await GetLocations()
                .Where(x => x.LocationType == locationType)
                .ToListAsync();
        }

        public async Task<List<Location>> GetLocationsByName(string name)
        {
            return await GetLocations()
                .Where(x => x.Name == name)
                .ToListAsync();
        }

        private IQueryable<Location> GetLocations()
        {
            return DbContext.Locations
                .Include(x => x.Product)
                .AsQueryable();
        }
    }
}