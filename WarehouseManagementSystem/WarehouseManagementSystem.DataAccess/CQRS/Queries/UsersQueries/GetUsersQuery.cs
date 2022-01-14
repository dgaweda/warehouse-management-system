using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;

namespace DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public override async Task<List<User>> Execute(WMSDatabaseContext context)
        {
            var users = await context.Users
                .Include(x => x.Role)
                .Include(x => x.Seniority)
                .ToListAsync();
            
            return users
                .FilterByUserId(UserId)
                .FilterByRoleName(RoleName)
                .FilterByPESEL(PESEL)
                .FilterByAge(Age)
                .FilterByName(Name)
                .FilterByLastName(LastName);

        }
    }
}