using System.Linq;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.ProductRepository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Product> GetAll()
        {
            return Entity
                .Include(x => x.PalletLines)
                .ThenInclude(x => x.Pallet)
                .AsQueryable();
        }
    }
}