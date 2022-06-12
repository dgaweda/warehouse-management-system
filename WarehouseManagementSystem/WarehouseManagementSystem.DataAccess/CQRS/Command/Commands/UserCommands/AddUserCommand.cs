using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using DataAccess.Entities;

namespace DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            Parameter.Password = BCrypt.Net.BCrypt.HashPassword(Parameter.Password);
            await context.AddRecord(Parameter);

            return Parameter;
        }
    }
}
