using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Commands.UserCommands;

namespace DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            Parameter.HashPassword();
            await context.Users.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
