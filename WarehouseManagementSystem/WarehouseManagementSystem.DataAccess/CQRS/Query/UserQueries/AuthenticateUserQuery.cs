using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.UserRepository;

namespace DataAccess.CQRS.Query.Queries.UsersQueries
{
    public class AuthenticateUserQuery : QueryBase<User, IUserRepository>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public override async Task<User> Execute(IUserRepository userRepository)
        {
            var user = await userRepository.GetUserByUsernameAsync(Username);
            
            return user.VerifyPassword(Password);
        }
    }
}
