using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Commands.UserCommands;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            Parameter.HashPassword();
            await context.Users.AddAsync(Parameter);
            await context.SaveChangesAsync();
            var addedRecord = await context.Users.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            return addedRecord;
        }
    }
}
