using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(IRepository<User> userRepository)
        {
            Parameter.Password = BCrypt.Net.BCrypt.HashPassword(Parameter.Password);
            await userRepository.AddAsync(Parameter);

            return Parameter;
        }
    }
}
