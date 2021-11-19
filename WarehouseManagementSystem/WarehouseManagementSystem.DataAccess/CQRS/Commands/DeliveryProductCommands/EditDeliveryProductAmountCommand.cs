using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class EditDeliveryProductAmountCommand : CommandBase<DeliveryProduct, DeliveryProduct>
    {
        public override async Task<DeliveryProduct> Execute(WMSDatabaseContext context)
        {
            var product = await context.DeliveryProducts
                .Include(x => x.DeliveryProductPalletLines)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            
            product.Amount = Parameter.Amount;
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
            
            return product;
        }
    }
}
