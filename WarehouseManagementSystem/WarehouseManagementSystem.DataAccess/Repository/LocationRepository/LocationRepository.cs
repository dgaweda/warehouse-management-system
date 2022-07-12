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
            return await GetQueryableEntity().ToListAsync();
        }

        public async Task<List<Location>> GetLocationsByType(LocationType locationType)
        {
            return await GetQueryableEntity()
                .Where(x => x.LocationType == locationType)
                .ToListAsync();
        }

        public async Task<List<Location>> GetLocationsByName(string name)
        {
            return await GetQueryableEntity()
                .Where(x => x.Name == name)
                .ToListAsync();
        }

        public override IQueryable<Location> GetQueryableEntity()
        {
            return Entity
                .Include(x => x.Product)
                .AsQueryable();
        }
    }
}