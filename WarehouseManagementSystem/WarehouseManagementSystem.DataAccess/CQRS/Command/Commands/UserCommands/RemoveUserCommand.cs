using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class RemoveUserCommand : CommandBase<User, User>
    {

        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await context.DeleteRecord(Parameter);
            return user;
        }
    }
}
