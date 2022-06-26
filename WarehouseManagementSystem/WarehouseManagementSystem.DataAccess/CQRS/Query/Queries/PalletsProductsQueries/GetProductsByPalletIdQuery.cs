using DataAccess.CQRS.Extensions;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.PalletsProductsQueries
{
    public class GetProductsByPalletIdQuery : QueryBase<List<ProductPalletLine>>
    {
        public int PalletId { get; set; }

        public override async Task<List<ProductPalletLine>> Execute(WMSDatabaseContext context)
        {
            var productPalletLines = await context.GetProductPalletLines();

            return productPalletLines.FilterByPalletId(PalletId);
        }
    }
}
