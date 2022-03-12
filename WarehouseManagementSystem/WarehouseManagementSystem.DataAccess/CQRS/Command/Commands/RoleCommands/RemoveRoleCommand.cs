using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class RemoveRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(WMSDatabaseContext context)
        {
            var role = await context.Roles.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await context.DeleteRecord(Parameter);
            return role;
        }
    }
}
