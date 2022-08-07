using System;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Extensions
{
    public static class ProductExtension
    {
        public static void SetProperties(this Product product, Product requestProduct)
        {
            product.Name = requestProduct.Name;
            product.Barcode = requestProduct.Barcode;
            product.ExpirationDate = requestProduct.ExpirationDate;
        }

        public static IQueryable<Product> FilterByName(this IQueryable<Product> products, string name)
        {
            if (string.IsNullOrEmpty(name))
                return products;

            return products.Where(x => x.Name.Contains(name));
        }

        public static IQueryable<Product> FilterByBarcode(this IQueryable<Product> products, string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
                return products;

            return products.Where(x => x.Barcode == barcode);
        }

        public static IQueryable<Product> FilterById(this IQueryable<Product> products, Guid? id)
        {
            if (id == Guid.Empty)
                return products;

            return products.Where(x => x.Id == id);
        }
    }
}
