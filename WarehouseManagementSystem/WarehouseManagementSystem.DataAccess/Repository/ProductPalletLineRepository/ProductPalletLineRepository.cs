using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.ProductPalletLineRepository
{
    public class ProductPalletLineRepository : Repository<ProductPalletLine>, IProductPalletLineRepository
    {
        public ProductPalletLineRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<ProductPalletLine>> GetAllAsync()
        {
            return await GetQueryableEntity()
                .ToListAsync();
        }

        public async Task<List<ProductPalletLine>> GetProductsByPalletId(Guid palletId)
        {
            return await GetQueryableEntity()
                .Where(x => x.PalletId == palletId)
                .ToListAsync();
        }

        public override IQueryable<ProductPalletLine> GetQueryableEntity()
        {
            return Entity
                .Include(x => x.Product)
                .Include(x => x.Pallet)
                .ThenInclude(pallet => pallet.Order)
                .Include(x => x.Pallet)
                .ThenInclude(pallet => pallet.Departure)
                .Include(x => x.Pallet)
                .ThenInclude(pallet => pallet.Invoice)
                .Include(x => x.Pallet)
                .ThenInclude(pallet => pallet.User)
                .AsQueryable();
        }
    }
}