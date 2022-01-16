using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.CQRS.Helpers
{
    public static class ProductHelper
    {
        public static void SetProperties(this Product product, Product requestProduct)
        {
            product.Name = requestProduct.Name;
            product.Barcode = requestProduct.Barcode;
            product.ExpirationDate = requestProduct.ExpirationDate;
        }

        public static List<Product> FilterByName(this List<Product> products, string name)
        {
            if (string.IsNullOrEmpty(name))
                return products;

            return products.Where(x => x.Name.Contains(name)).ToList();
        }

        public static List<Product> FilterByBarcode(this List<Product> products, string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
                return products;

            return products.Where(x => x.Barcode == barcode).ToList();
        }

        public static List<Product> FilterById(this List<Product> products, int id)
        {
            if (id == 0)
                return products;

            return products.Where(x => x.Id == id).ToList();
        }
    }
}
