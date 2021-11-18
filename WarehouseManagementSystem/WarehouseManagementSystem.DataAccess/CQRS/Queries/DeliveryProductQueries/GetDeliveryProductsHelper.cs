using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.DeliveryProductQueries
{
    public class GetDeliveryProductsHelper : IGetEntityHelper<DeliveryProduct>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Barcode { get; set; }
        public async Task<List<DeliveryProduct>> GetFilteredData(WMSDatabaseContext context)
        {
            var deliveryProducts = await context.DeliveryProducts
                .Include(x => x.DeliveryProductPalletLines)
                    .ThenInclude(x => x.Pallet)
                .ToListAsync();
            if (PropertiesAreEmpty())
                return deliveryProducts;

            if (!string.IsNullOrEmpty(Name))
                deliveryProducts = SearchByName(deliveryProducts);

            if (!string.IsNullOrEmpty(Barcode))
                deliveryProducts = SearchByBarcode(deliveryProducts);

            if (Id != 0)
                deliveryProducts = SearchById(deliveryProducts);

            return deliveryProducts;
        }

        public bool PropertiesAreEmpty() => string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Barcode) && Id == 0;

        private List<DeliveryProduct> SearchByName(List<DeliveryProduct> deliveryProducts) => deliveryProducts.Where(x => x.Name.Contains(Name)).ToList();
        private List<DeliveryProduct> SearchByBarcode(List<DeliveryProduct> deliveryProducts) => deliveryProducts.Where(x => x.Barcode == Barcode).ToList();
        private List<DeliveryProduct> SearchById(List<DeliveryProduct> deliveryProducts) => deliveryProducts.Where(x => x.Id == Id).ToList();
    }
}
