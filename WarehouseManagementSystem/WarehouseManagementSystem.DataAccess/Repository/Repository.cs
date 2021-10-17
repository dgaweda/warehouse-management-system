using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly WMSDatabaseContext context;
        private readonly DbSet<T> entities;

        public Repository(WMSDatabaseContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public Task Delete(int id)
        {
            T record = entities.SingleOrDefault(i => i.Id == id);

            entities.Remove(record);
            return SaveChanges();
        }

        public Task<List<T>> GetAll() => entities.ToListAsync();

        public Task<T> GetById(int id) => entities.SingleOrDefaultAsync(i => i.Id == id);

        public Task Insert(T entity)
        {
            if (IsNull(entity))
                throw new ArgumentNullException();

            entities.Add(entity);
            return SaveChanges();
        }

        public Task Update(T entity)
        {
            if(IsNull(entity))
                throw new ArgumentNullException();

            entities.Update(entity);
            return SaveChanges();
        }

        private bool IsNull(T entity) => entity == null;

        private Task SaveChanges() => context.SaveChangesAsync();
    }
}
