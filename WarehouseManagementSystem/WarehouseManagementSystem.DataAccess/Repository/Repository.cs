#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : EntityBase
    {
        private readonly WMSDatabaseContext _context;
        public DbSet<TEntity> Entity { get; }

        protected Repository(WMSDatabaseContext dbContext)
{
            _context = dbContext;
            Entity = _context.Set<TEntity>();
        }

        public WMSDatabaseContext GetDbContext()
        {
            return _context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Entity.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await Entity.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
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

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await Entity.FirstOrDefaultAsync(x => x.Id == id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(TEntity)} with id: {id} doesn't exist.");

            Entity.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var entityToDetach = await Entity.FirstOrDefaultAsync(x => x.Id == entity.Id);
            
            if (entityToDetach == null)
                throw new NotFoundException($"{nameof(TEntity)} with id: {entity.Id} doesn't exist.");
            
            _context.Entry(entityToDetach).State = EntityState.Detached;
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public abstract IQueryable<TEntity> GetQueryableEntity();
    }
}
