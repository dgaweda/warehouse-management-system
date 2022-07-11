using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class RemoveUserCommand : CommandBase<User, IUserRepository>
    {

        public override async Task Execute(IUserRepository userRepository)
        {
            await userRepository.DeleteAsync(Parameter.Id);
        }
    }
}
