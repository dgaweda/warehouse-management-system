using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.ProductPalletLineRepository;

namespace DataAccess.CQRS.Query.PalletsProductsQueries
{
    public class GetProductsByPalletIdQuery : QueryBase<List<ProductPalletLine>, IProductPalletLineRepository>
    {
        public Guid PalletId { get; set; }

        public override async Task<List<ProductPalletLine>> Execute(IProductPalletLineRepository productPalletLineRepository)
        {
            return await productPalletLineRepository.GetProductsByPalletId(PalletId);
        }
    }
}
