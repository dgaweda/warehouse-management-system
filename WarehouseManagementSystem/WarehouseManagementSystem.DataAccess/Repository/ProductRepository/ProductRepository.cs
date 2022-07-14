using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.ProductRepository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Product>> GetAllAsync()
        {
            return await GetQueryableEntity()
                .AsNoTracking()
                .ToListAsync();
        }

        public override IQueryable<Product> GetQueryableEntity()
        {
            return Entity
                .Include(x => x.PalletLines)
                .ThenInclude(x => x.Pallet)
                .AsQueryable();
        }
    }
}