﻿using System;
using System.Collections.Generic;
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

        public static List<Product> FilterById(this List<Product> products, Guid? id)
        {
            if (id == Guid.Empty)
                return products;

            return products.Where(x => x.Id == id).ToList();
        }
    }
}
