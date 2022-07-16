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

        public async Task<List<ProductPalletLine>> GetProductsByPalletId(Guid palletId)
        {
            return await GetAll()
                .Where(x => x.PalletId == palletId)
                .ToListAsync();
        }

        public async Task<bool> PalletIsEmpty(Guid palletId)
        { 
            return !await GetAll().AnyAsync(x => x.PalletId == palletId);
        }

        public override IQueryable<ProductPalletLine> GetAll()
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