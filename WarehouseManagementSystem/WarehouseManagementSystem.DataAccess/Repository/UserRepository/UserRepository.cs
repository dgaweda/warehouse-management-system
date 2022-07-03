using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
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
            return await GetUsers().ToListAsync();
        }
        
        public override async Task<User> GetByIdAsync(int id)
        {
            return await GetUsers().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await GetUsers().FirstOrDefaultAsync(x => x.UserName.Equals(username));
        }
        
        private IQueryable<User> GetUsers()
        {
            return DbContext.Users
                .Include(x => x.Seniority)
                .Include(x => x.Role)
                .Include(x => x.Pallets)
                .AsQueryable();
        }
    }
}