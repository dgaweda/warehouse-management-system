using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.RoleQueries
{
    public class GetRolesHelper : IGetEntityHelper<Role>
    { 
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public async Task<List<Role>> GetFilteredData(WMSDatabaseContext context)
        {
            var roles = await context.Roles.ToListAsync();

            if (RoleId != 0)
                roles = await SearchById(context);
            else
                roles = await SearchByRoleName(context);

            return roles;
        }

        private async Task<List<Role>> SearchById(WMSDatabaseContext context) => await context.Roles.Where(role => role.Id == RoleId).ToListAsync();
        private async Task<List<Role>> SearchByRoleName(WMSDatabaseContext context) => await context.Roles.Where(role => role.Name.Contains(RoleName)).ToListAsync();
        
        public bool PropertiesAreEmpty() => RoleId == 0 && string.IsNullOrEmpty(RoleName);
    }
}
