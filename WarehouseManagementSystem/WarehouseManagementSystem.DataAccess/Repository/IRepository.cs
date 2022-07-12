using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities.EntityBases;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        DbSet<T> Entity { get; }
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetQueryableEntity();
    }
}
