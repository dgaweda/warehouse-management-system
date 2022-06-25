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
            await userRepository.Update(Parameter);

            var updatedRecord = await userRepository.GetEntity()
                .Include(x => x.Role)
                .FirstOrDefaultAsync(user => user.Id == Parameter.Id);

            return updatedRecord;
        }
    }
}
