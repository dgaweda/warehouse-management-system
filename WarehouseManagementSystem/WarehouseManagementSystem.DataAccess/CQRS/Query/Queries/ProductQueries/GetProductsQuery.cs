using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.DeliveryProductQueries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Barcode { get; set; }

        public override async Task<List<Product>> Execute(WMSDatabaseContext context)
        {
            var products = await context.Products
                .Include(x => x.PalletLines)
                .ThenInclude(x => x.Pallet)
                .ToListAsync();


            return products
                .FilterByName(Name)
                .FilterByBarcode(Barcode)
                .FilterById(Id);
        }
    }
}
