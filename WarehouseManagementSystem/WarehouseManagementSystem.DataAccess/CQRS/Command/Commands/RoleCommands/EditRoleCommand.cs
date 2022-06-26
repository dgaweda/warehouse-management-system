using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class EditRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(IRepository<Role> roleRepository)
        {
            await roleRepository.UpdateAsync(Parameter);
            return Parameter;
        }
    }
}
