using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands
{
    public class EditUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            await context.UpdateRecord(Parameter);

            var updatedRecord = await context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(user => user.Id == Parameter.Id);

            return updatedRecord;
        }
    }
}
