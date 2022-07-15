using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<User>> GetAllAsync()
        {
            return await GetQueryableEntity().ToListAsync();
        }

        public override async Task<User> GetByIdAsync(Guid id)
        {
            return await GetQueryableEntity().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await GetQueryableEntity().FirstOrDefaultAsync(x => x.UserName.Equals(username));
        }

        public override IQueryable<User> GetQueryableEntity()
        {
            return Entity
                .Include(x => x.Seniority)
                .Include(x => x.Role)
                .Include(x => x.Pallets)
                .AsQueryable();
        }
    }
}