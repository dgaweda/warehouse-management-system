using DataAccess.CQRS.Extensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.RoleQueries
{
    public class GetRolesQuery : QueryBase<List<Role>>
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public override async Task<List<Role>> Execute(WMSDatabaseContext context)
        {
            var roles = await context.Roles.ToListAsync();

            return roles
                .FilterById(RoleId)
                .FilterByRoleName(RoleName);
        }
    }
}
