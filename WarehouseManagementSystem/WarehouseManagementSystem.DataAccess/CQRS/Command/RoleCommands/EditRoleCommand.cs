using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.RoleRepository;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class EditRoleCommand : CommandBase<Role, Role, IRoleRepository>
    {
        public override async Task<Role> Execute(IRoleRepository roleRepository)
        {
            return await roleRepository.UpdateAsync(Parameter);
        }
    }
}
