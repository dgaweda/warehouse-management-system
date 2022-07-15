using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.RoleRepository;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class RemoveRoleCommand : CommandBase<Role, IRoleRepository>
    {
        public override async Task Execute(IRoleRepository roleRepository)
        {
           await roleRepository.DeleteAsync(Parameter.Id);
        }
    }
}
