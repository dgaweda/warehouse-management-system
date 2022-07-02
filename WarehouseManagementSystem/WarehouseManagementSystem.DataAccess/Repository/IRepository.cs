using DataAccess.Entities.EntityBases;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        DbSet<T> Entity { get; }
        WMSDatabaseContext GetDbContext();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        
    }
}
