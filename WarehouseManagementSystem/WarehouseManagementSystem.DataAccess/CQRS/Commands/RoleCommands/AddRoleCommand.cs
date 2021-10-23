using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class AddRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(WMSDatabaseContext context)
        {
            if (Parameter == null)
                throw new ArgumentNullException();

            await context.Roles.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
