using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.UserQueries
{
    public class GetUsersQuery : QueryBase<User>
    {
        public string UserName { get; set; }

        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            return await context.Users
                .Include(x => x.Employee)
                .Include(x => x.Employee.Role)
                .FirstOrDefaultAsync(x => x.UserName == UserName);
        }
        
    }
}
