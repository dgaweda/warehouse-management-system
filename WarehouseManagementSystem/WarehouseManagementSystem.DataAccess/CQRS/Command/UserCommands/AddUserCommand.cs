using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.UserRepository;

namespace DataAccess.CQRS.Command.Commands.UserCommands
{
    public class AddUserCommand : CommandBase<User, User, IUserRepository>
    {
        public override async Task<User> Execute(IUserRepository userRepository)
        {
            Parameter.Password = BCrypt.Net.BCrypt.HashPassword(Parameter.Password);
            return await userRepository.AddAsync(Parameter);
        }
    }
}
