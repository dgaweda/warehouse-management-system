using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class EditUserCommand : CommandBase<User, User, IUserRepository>
    {
        public override async Task<User> Execute(IUserRepository userRepository)
        {
            return await userRepository.UpdateAsync(Parameter);
        }
    }
}
