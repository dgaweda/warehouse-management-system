using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository.ProductPalletLineRepository
{
    public interface IProductPalletLineRepository : IRepository<PalletRow>
    {
        Task<List<PalletRow>> GetProductsByPalletId(Guid palletId);

        Task<bool> PalletIsEmpty(Guid? id);
    }
}