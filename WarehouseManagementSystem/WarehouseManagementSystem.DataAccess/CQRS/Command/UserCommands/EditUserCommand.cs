using DataAccess.Entities;
using System.Threading.Tasks;
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
            await userRepository.UpdateAsync(Parameter);

            var updatedRecord = await userRepository.Entity
                .Include(x => x.Role)
                .FirstOrDefaultAsync(user => user.Id == Parameter.Id);

            return updatedRecord;
        }
    }
}
