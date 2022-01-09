using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
