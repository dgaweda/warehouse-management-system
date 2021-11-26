using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.DeliveryProductQueries
{
    public class GetProductsHelper : IGetEntityHelper<Product>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Barcode { get; set; }

        public async Task<List<Product>> GetFilteredData(WMSDatabaseContext context)
        {
            var products = await context.Products
                .Include(x => x.PalletLines)
                    .ThenInclude(x => x.Pallet)
                .ToListAsync();

            if (PropertiesAreEmpty())
                return products;

            if (!string.IsNullOrEmpty(Name))
                products = SearchByName(products);

            if (!string.IsNullOrEmpty(Barcode))
                products = SearchByBarcode(products);

            if (Id != 0)
                products = SearchById(products);

            return products;
        }

        public bool PropertiesAreEmpty() => string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Barcode) && Id == 0;

        private List<Product> SearchByName(List<Product> products) => products.Where(x => x.Name.Contains(Name)).ToList();
        private List<Product> SearchByBarcode(List<Product> products) => products.Where(x => x.Barcode == Barcode).ToList();
        private List<Product> SearchById(List<Product> products) => products.Where(x => x.Id == Id).ToList();
    }
}
