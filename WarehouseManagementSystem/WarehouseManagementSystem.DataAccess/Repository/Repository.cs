using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : class, IEntityBase
    {
        private readonly WMSDatabaseContext _dbContext;
        public DbSet<TEntity> Entity => _dbContext.Set<TEntity>();

        public Repository(WMSDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Entity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public WMSDatabaseContext GetDbContext()
        {
            return _dbContext;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Entity.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await Entity.FirstOrDefaultAsync(x => x.Id == id);

            if (entityToDelete != null)
            {
                _dbContext.Set<TEntity>().Remove(entityToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityToDetach = await Entity.FirstOrDefaultAsync(x => x.Id == entity.Id);

            // _dbContext.Update(entity);
            _dbContext.Entry(entityToDetach).State = EntityState.Detached;
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
