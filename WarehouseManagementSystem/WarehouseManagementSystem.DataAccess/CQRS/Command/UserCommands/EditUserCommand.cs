using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.UserRepository;

namespace DataAccess.CQRS.Commands
{
    public class EditUserCommand : CommandBase<User, IUserRepository>
    {
        public override async Task Execute(IUserRepository userRepository)
        {
            await userRepository.UpdateAsync(Parameter);
        }
    }
}
