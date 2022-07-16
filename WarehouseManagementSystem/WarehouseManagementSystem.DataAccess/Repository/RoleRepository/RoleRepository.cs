using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Repository.RoleRepository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Role> GetAll()
        {
            return Entity.AsQueryable();
        }
    }
}