using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.UserRepository;

namespace DataAccess.AuthenticateUserService
{
    public class AuthenticateUserQuery : QueryBase<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            var user = await RepositoryService.GetUserByUsernameAsync(Username);
            
            return user.VerifyPassword(Password);
        }
    }
}
