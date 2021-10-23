using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class EditRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(WMSDatabaseContext context)
        {
            context.Entry(Parameter).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
