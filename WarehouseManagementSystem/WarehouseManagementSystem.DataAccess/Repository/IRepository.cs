using DataAccess.Entities.EntityBases;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class, IEntityBase
    {
        DbSet<T> Entity { get; }
        
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
        WMSDatabaseContext GetDbContext();
    }
}
