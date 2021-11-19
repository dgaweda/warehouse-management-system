using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class EditDeliveryProductCommand : CommandBase<DeliveryProduct, DeliveryProduct>
    {
        public override async Task<DeliveryProduct> Execute(WMSDatabaseContext context)
        {
            var product = await context.DeliveryProducts
                .Include(x => x.DeliveryProductPalletLines)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            SetProperties(product);

            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return product;
        }

        private void SetProperties(DeliveryProduct product)
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
