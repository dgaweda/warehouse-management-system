using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}