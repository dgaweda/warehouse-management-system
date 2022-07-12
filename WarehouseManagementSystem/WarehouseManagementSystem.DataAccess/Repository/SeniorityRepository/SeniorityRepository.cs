using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.SeniorityRepository
{
    public class SeniorityRepository : Repository<Seniority>, ISeniorityRepository    
    {
        public SeniorityRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Seniority>> GetAllAsync()
        {
            return await GetQueryableEntity().ToListAsync();
        }

        public override IQueryable<Seniority> GetQueryableEntity()
        {
            return Entity
                .Include(x => x.User)
                .AsQueryable();
        }
    }
}