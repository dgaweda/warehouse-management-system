using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            Parameter.HashPassword();
            await context.AddRecord(Parameter);
            var addedRecord = await context.Users.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            return addedRecord;
        }
    }
}
