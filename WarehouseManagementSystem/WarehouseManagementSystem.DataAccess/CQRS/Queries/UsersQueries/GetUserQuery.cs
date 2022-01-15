using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.UsersQueries
{
    public class GetUserQuery : QueryBase<User>
    {
        public string UserName { get; set; }
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            return await context.Users
                .Include(x => x.Seniority)
                .Include(x => x.Role)
                .Include(x => x.Pallets)
                .FirstOrDefaultAsync(x => x.UserName.Equals(UserName));
        }

    }
}
