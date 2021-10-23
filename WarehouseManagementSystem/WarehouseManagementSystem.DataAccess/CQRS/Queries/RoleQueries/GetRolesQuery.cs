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
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public override async Task<List<Role>> Execute(WMSDatabaseContext context)
        {
            var roles = await context.Roles.Where(role =>
                RoleId == 0 || RoleName == null ? 
                RoleId == 0 && RoleName != null ? 
                    role.Name == RoleName : 
                    role.Id == RoleId :
                    role.Id == RoleId && role.Name == RoleName)
                .ToListAsync();

            if (RoleId == 0 && RoleName == null)
                return await context.Roles.ToListAsync();
            return roles;
        }
    }
}
