using DataAccess.CQRS.Queries.PalletLineQueries;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.PalletsProductsQueries
{
    public class GetProductsByPalletIdQuery : QueryBase<List<ProductPalletLine>>
    {
        private readonly IGetEntityHelper<ProductPalletLine> _products;

        public GetProductsByPalletIdQuery(IGetEntityHelper<ProductPalletLine> products)
        {
            _products = products;
        }
        public override async Task<List<ProductPalletLine>> Execute(WMSDatabaseContext context) => await _products.GetFilteredData(context);
    }
}
