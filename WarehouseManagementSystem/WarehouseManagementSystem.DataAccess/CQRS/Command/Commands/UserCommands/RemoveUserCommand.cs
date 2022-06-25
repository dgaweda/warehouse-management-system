using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands
{
    public class RemoveUserCommand : CommandBase<User, User>
    {

        public override async Task<User> Execute(IRepository<User> repositoryService)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await context.Delete(Parameter);
            return user;
        }
    }
}
