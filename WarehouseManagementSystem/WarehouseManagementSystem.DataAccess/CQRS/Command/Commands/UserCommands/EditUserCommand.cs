using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class EditUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(IRepository<User> userRepository)
        {
            await userRepository.UpdateAsync(Parameter);

            var updatedRecord = await userRepository.Entity
                .Include(x => x.Role)
                .FirstOrDefaultAsync(user => user.Id == Parameter.Id);

            return updatedRecord;
        }
    }
}
