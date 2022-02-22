using System.Reflection.Metadata;
using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            Parameter.Password.Hash(Parameter);
            Parameter.SetData();
            await context.AddRecord(Parameter);

            return Parameter;
        }
    }
}
