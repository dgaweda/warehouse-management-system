using DataAccess.Entities.EntityBases;

namespace DataAccess.CQRS.Helpers
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    namespace DataAccess.Repository
    {
        public static class Repository
        {
            public static async Task AddRecord<TEntity>(this WMSDatabaseContext context, TEntity entity)
                where TEntity : class, IEntityBase
            {
                var entities = context.Set<TEntity>();

                await entities.AddAsync(entity);
                await context.SaveChangesAsync();
            }

            public static async Task<TEntity> GetById<TEntity>(this WMSDatabaseContext context, int id)
                where TEntity : class, IEntityBase
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == id);
            }

            public static async Task DeleteRecord<TEntity>(this WMSDatabaseContext context, TEntity entity)
                where TEntity : class, IEntityBase
            {
                var entities = context.Set<TEntity>();
                var entityToDelete = await entities.FirstOrDefaultAsync(x => x.Id == entity.Id);

                if (entityToDelete != null)
                {
                    entities.Remove(entityToDelete);
                    await context.SaveChangesAsync();
                }
            }

            public static async Task UpdateRecord<TEntity>(this WMSDatabaseContext context, TEntity entity)
                where TEntity : class, IEntityBase
            {
                var entities = context.Set<TEntity>();

                var entityToDetach = await entities.FirstOrDefaultAsync(x => x.Id == entity.Id);

                context.Entry(entityToDetach).State = EntityState.Detached;
                context.Entry(entity).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }
    }

}
