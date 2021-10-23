using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.RoleQueries
{
    public class GetRolesQuery : QueryBase<List<Role>>
    {
        public override async Task<List<Role>> Execute(WMSDatabaseContext context) => await context.Roles.ToListAsync();
    }
}
