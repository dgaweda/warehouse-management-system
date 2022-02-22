using DataAccess.Entities;

namespace DataAccess.CQRS.Queries.UsersQueries
{
    public interface IAuthenticateUserService
    {
        bool HasCorrectPassword(User user, string password);
        (string Password, byte[] SaltBytes) HashPassword(string password, User user);
        void SetData(User user, string password, byte[] salt);
    }
}