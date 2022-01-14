using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class AddRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(WMSDatabaseContext context)
        {
            await context.AddRecord(Parameter);
            return Parameter;
        }
    }
}
