using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class RemoveRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(IRepository<Role> roleRepository)
        {
            var role = await roleRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await roleRepository.DeleteAsync(Parameter.Id);
            return role;
        }
    }
}
