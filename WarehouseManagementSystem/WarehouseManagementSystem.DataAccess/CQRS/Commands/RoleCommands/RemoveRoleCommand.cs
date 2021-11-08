using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class RemoveRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(WMSDatabaseContext context)
        {
            var role = await context.Roles.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            context.Roles.Remove(role);
            await context.SaveChangesAsync();

            return role;
        }
    }
}
