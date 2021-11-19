using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class RemoveDeliveryProductCommand : CommandBase<DeliveryProduct, DeliveryProduct>
    {
        public override async Task<DeliveryProduct> Execute(WMSDatabaseContext context)
        {
            var product = await context.DeliveryProducts.FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            if (product == null)
                throw new ArgumentNullException();
                
            context.Remove(product);
            await context.SaveChangesAsync();

            return product;
        }
    }
}
