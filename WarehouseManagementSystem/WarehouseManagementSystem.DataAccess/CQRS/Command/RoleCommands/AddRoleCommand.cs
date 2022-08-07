using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.RoleRepository;

namespace DataAccess.CQRS.Command.RoleCommands
{
    public class AddRoleCommand : CommandBase<Role, IRoleRepository>
    {
        public override async Task Execute(IRoleRepository roleRepository)
        {
            await roleRepository.AddAsync(Parameter);
        }
    }
}
