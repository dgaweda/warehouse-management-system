using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class EditDeliveryProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(WMSDatabaseContext context)
        {
            var product = await context.Products
                .Include(x => x.PalletLines)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            SetProperties(product);

            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return product;
        }

        private void SetProperties(Product product)
        {
            if (!string.IsNullOrEmpty(Parameter.Name))
                product.Name = Parameter.Name;

            if (!string.IsNullOrEmpty(Parameter.Barcode))
                product.Barcode = Parameter.Barcode;

            if (Parameter.ExpirationDate > DateTime.Now)
                product.ExpirationDate = Parameter.ExpirationDate;
        }
    }
}
