using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.UserRepository;

namespace DataAccess.CQRS.Command.UserCommands
{
    public class EditUserCommand : CommandBase<User, IUserRepository>
    {
        public override async Task Execute(IUserRepository userRepository)
        {
            await userRepository.UpdateAsync(Parameter);
        }
    }
}
