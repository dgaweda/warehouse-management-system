using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.RoleRepository;

namespace DataAccess.CQRS.Command.RoleCommands
{
    public class EditRoleCommand : CommandBase<Role, IRoleRepository>
    {
        public override async Task Execute(IRoleRepository roleRepository)
        {
            await roleRepository.UpdateAsync(Parameter);
        }
    }
}
