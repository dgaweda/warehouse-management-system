using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class RemoveUserCommand : CommandBase<User, Unit, IUserRepository>
    {

        public override async Task<Unit> Execute(IUserRepository userRepository)
        {
           return await userRepository.DeleteAsync(Parameter.Id);
        }
    }
}
