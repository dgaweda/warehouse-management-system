using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.UserRepository;

namespace DataAccess.CQRS.Command.UserCommands
{
    public class AddUserCommand : CommandBase<User, IUserRepository>
    {
        public override async Task Execute(IUserRepository userRepository)
        {
            Parameter.Password = BCrypt.Net.BCrypt.HashPassword(Parameter.Password);
            await userRepository.AddAsync(Parameter);
        }
    }
}
