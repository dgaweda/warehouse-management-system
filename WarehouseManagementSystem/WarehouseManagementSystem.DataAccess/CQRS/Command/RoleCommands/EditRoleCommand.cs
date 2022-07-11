using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.RoleRepository;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class EditRoleCommand : CommandBase<Role, IRoleRepository>
    {
        public override async Task Execute(IRoleRepository roleRepository)
        {
            await roleRepository.UpdateAsync(Parameter);
        }
    }
}
