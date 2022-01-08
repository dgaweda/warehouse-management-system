﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities.EntityBases;
using DataAccess.Migrations;

namespace DataAccess.CQRS.Helpers
{
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
            public static async Task<TEntity> AddRecord<TEntity>(this WMSDatabaseContext context, TEntity entity)
                where TEntity : class, IEntityBase
            {
                var entities = context.Set<TEntity>();

                await entities.AddAsync(entity);
                await context.SaveChangesAsync();

                return entity;
            }

            public static async Task<List<TEntity>> GetAll<TEntity>(this WMSDatabaseContext context)
                where TEntity : class, IEntityBase
            {
                return await context.Set<TEntity>().ToListAsync();
            }

            public static async Task<TEntity> GetById<TEntity>(this WMSDatabaseContext context, int Id)
                where TEntity : class, IEntityBase
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == Id);
            }

            public static async Task<TEntity> DeleteRecord<TEntity>(this WMSDatabaseContext context, TEntity entity)
                where TEntity : class, IEntityBase
            {
                var entities = context.Set<TEntity>();
                var entityToDelete = await entities.FirstOrDefaultAsync(x => x.Id == entity.Id);

                if (entityToDelete != null)
                {
                    entities.Remove(entityToDelete);
                    await context.SaveChangesAsync();
                }

                return entityToDelete;
            }

            public static async Task<TEntity> UpdateRecord<TEntity>(this WMSDatabaseContext context, TEntity entity)
                where TEntity : class, IEntityBase
            {
                var entities = context.Set<TEntity>();

                var entityToDetach = entities.FirstOrDefaultAsync(x => x.Id == entity.Id);

                context.Entry(entityToDetach).State = EntityState.Detached;
                context.Entry(entity).State = EntityState.Modified;

                await context.SaveChangesAsync();

                return await entities.FirstOrDefaultAsync(x => x.Id == entity.Id);
            }
        }
    }

}
