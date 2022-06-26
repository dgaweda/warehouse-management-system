using DataAccess.Entities.EntityBases;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class, IEntityBase
    {
        DbSet<T> Entity { get; }
        
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        WMSDatabaseContext GetDbContext();
    }
}
