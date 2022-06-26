using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class AddRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(IRepository<Role> roleRepository)
        {
            await roleRepository.AddAsync(Parameter);
            return Parameter;
        }
    }
}
