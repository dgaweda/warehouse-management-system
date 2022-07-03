using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
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
            return await DbContext.Products
                .Include(x => x.PalletLines)
                .ThenInclude(x => x.Pallet)
                .ToListAsync();
        }
    }
}