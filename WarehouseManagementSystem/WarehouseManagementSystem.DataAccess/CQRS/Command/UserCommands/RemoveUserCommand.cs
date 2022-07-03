using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class RemoveUserCommand : CommandBase<User, User, IUserRepository>
    {

        public override async Task<User> Execute(IUserRepository userRepository)
        {
            var user = await userRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await userRepository.DeleteAsync(Parameter.Id);
            return user;
        }
    }
}
