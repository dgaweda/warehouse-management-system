using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public static class Repository
    {
        public static async Task<TEntity> Add<TEntity>(this WMSDatabaseContext context, TEntity entity)
            where TEntity : class, IEntityBase
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public static async Task<List<TEntity>> GetAll<TEntity>(this WMSDatabaseContext context)
            where TEntity : class, IEntityBase
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public static async Task<TEntity> Get<TEntity>(this WMSDatabaseContext context, int id)
            where TEntity : class, IEntityBase
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(i => i.Id == id);
        }

        public static async Task<TEntity> Delete<TEntity>(this WMSDatabaseContext context, int id)
            where TEntity : class, IEntityBase
        {
            var entities = context.Set<TEntity>();
            var entity = entities.SingleOrDefault(i => i.Id == id);

            if (entity is null)
            {
                return entity;
            }

            entities.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public static async Task<TEntity> Update<TEntity>(this WMSDatabaseContext context, TEntity entity)
            where TEntity : class, IEntityBase
        {
            var entityToDetach = context.Set<TEntity>();

            context.Entry(entityToDetach).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return entity;
        }
    }
}
