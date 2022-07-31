using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.LocationRepository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Location>> GetLocationsByType(LocationType locationType)
        {
            return await GetAll()
                .Where(x => x.LocationType == locationType)
                .ToListAsync();
        }

        public async Task<List<Location>> GetLocationsByName(string name)
        {
            return await GetAll()
                .Where(x => x.Name == name)
                .ToListAsync();
        }

        public override IQueryable<Location> GetAll()
        {
            return Entity
                .Include(x => x.Product)
                .AsQueryable();
        }
    }
}