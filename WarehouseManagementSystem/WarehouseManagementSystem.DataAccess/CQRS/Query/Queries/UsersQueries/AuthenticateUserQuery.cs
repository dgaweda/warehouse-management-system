using System.Threading.Tasks;
using DataAccess.CQRS.Queries;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.AuthenticateUserService
{
    public class AuthenticateUserQuery : QueryBase<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            var user = await context.Users
                .Include(x => x.Seniority)
                .Include(x => x.Role)
                .Include(x => x.Pallets)
                .FirstOrDefaultAsync(x => x.UserName.Equals(Username));
            
            var hasCorrectPassword = BCrypt.Net.BCrypt.Verify(Password, user.Password);
            return hasCorrectPassword ? user : null;
        }
    }
}
