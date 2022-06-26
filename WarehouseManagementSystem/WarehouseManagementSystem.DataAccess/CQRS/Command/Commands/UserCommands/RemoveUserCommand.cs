using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class RemoveUserCommand : CommandBase<User, User>
    {

        public override async Task<User> Execute(IRepository<User> userRepository)
        {
            var user = await userRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await userRepository.DeleteAsync(Parameter.Id);
            return user;
        }
    }
}
