using System.Linq;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.SeniorityRepository
{
    public class SeniorityRepository : Repository<Seniority>, ISeniorityRepository    
    {
        public SeniorityRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Seniority> GetAll()
        {
            return Entity
                .Include(x => x.User)
                .AsQueryable();
        }
    }
}