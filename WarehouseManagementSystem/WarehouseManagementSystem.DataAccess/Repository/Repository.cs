using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class, IEntityBase
        where TContext : DbContext
    {
        protected readonly TContext _context;
        private DbSet<TEntity> entities;

        public Repository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<TEntity> Delete(int id)
        {
            entities = _context.Set<TEntity>();
            var entity = entities.SingleOrDefault(i => i.Id == id);

            if (entity is null)
            {
                return entity;
            }

            entities.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var entityToDetach = _context.Set<TEntity>();

            _context.Entry(entityToDetach).State = EntityState.Modified;
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
