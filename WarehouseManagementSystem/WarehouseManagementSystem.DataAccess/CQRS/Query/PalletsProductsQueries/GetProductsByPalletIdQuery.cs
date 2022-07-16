using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.ProductPalletLineRepository;

namespace DataAccess.CQRS.Query.PalletsProductsQueries
{
    public class GetProductsByPalletIdQuery : QueryBase<List<ProductPalletLine>>
    {
        private readonly IProductPalletLineRepository _productPalletLineRepository;

        public GetProductsByPalletIdQuery(IProductPalletLineRepository productPalletLineRepository)
        {
            _productPalletLineRepository = productPalletLineRepository;
        }

        public Guid PalletId { get; set; }

        public override async Task<List<ProductPalletLine>> Execute()
        {
            return await _productPalletLineRepository.GetProductsByPalletId(PalletId);
        }
    }
}
