using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities.EntityBase;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        WMSDatabaseContext GetDbContext();
        DbSet<T> Entity { get; }
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        IQueryable<T> GetAll();
    }
}
