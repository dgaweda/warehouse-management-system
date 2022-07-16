using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.UserRepository;

namespace DataAccess.CQRS.Query.Queries.UsersQueries
{
    public class AuthenticateUserQuery : QueryBase<User>
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUserQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        
        public override async Task<User> Execute()
        {
            var user = await _userRepository.GetUserByUsernameAsync(Username);
            
            return user.VerifyPassword(Password);
        }
    }
}
