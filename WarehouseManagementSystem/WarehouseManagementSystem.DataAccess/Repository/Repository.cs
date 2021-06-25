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
        private DbSet<T> entities;

        public Repository(WMSDatabaseContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(int id)
        {
            T record = entities.SingleOrDefault(i => i.Id == id);
            entities.Remove(record);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll() => entities.AsEnumerable();

        public T GetById(int id) => entities.SingleOrDefault(i => i.Id == id);

        public void Insert(T entity)
        {
            checkIfNull(entity);

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            checkIfNull(entity);

            entities.Update(entity);
            context.SaveChanges();
        }

        public void checkIfNull(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is Null");
        }
    }
}
