using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.RoleRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class RemoveRoleCommand : CommandBase<Role, Role, IRoleRepository>
    {
        public override async Task<Role> Execute(IRoleRepository roleRepository)
        {
            var role = await roleRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await roleRepository.DeleteAsync(Parameter.Id);
            return role;
        }
    }
}
