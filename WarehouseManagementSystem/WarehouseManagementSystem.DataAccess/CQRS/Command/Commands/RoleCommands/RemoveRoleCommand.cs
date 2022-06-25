using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class RemoveRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(IRepository<Role> roleRepository)
        {
            var role = await context.Roles.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await context.Delete(Parameter);
            return role;
        }
    }
}
