using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.RoleRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class RemoveRoleCommand : CommandBase<Role, IRoleRepository>
    {
        public override async Task<Unit> Execute(IRoleRepository roleRepository)
        {
           await roleRepository.DeleteAsync(Parameter.Id);
        }
    }
}
