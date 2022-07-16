using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository.ProductPalletLineRepository
{
    public interface IProductPalletLineRepository : IRepository<ProductPalletLine>
    {
        Task<List<ProductPalletLine>> GetProductsByPalletId(Guid palletId);

        Task<bool> PalletIsEmpty(Guid id);
    }
}