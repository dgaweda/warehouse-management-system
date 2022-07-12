#nullable enable
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : EntityBase
    {
        private readonly WMSDatabaseContext DbContext;
        public DbSet<TEntity> Entity { get; }

        protected Repository(WMSDatabaseContext dbContext)
{
            DbContext = dbContext;
            Entity = DbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Entity.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            
            return entity;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            await Entity.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
            
            return entities;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var result = await Entity.FirstOrDefaultAsync(i => i.Id == id);
            if (result is null)
                throw new NotFoundException($"{nameof(TEntity)} with id: {id} doesn't exist.");
            
            return result;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await Entity.FirstOrDefaultAsync(x => x.Id == id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(TEntity)} with id: {id} doesn't exist.");
            
            DbContext.Set<TEntity>().Remove(entityToDelete);
            await DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityToDetach = await Entity.FirstOrDefaultAsync(x => x.Id == entity.Id);
            
            if (entityToDetach == null)
                throw new NotFoundException($"{nameof(TEntity)} with id: {entity.Id} doesn't exist.");
            
            DbContext.Entry(entityToDetach).State = EntityState.Detached;
            DbContext.Entry(entity).State = EntityState.Modified;

            await DbContext.SaveChangesAsync();
            return entity;
        }

        public abstract IQueryable<TEntity> GetQueryableEntity();
    }
}
