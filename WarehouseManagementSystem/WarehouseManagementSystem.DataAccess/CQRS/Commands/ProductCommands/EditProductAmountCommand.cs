using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class EditProductAmountCommand : CommandBase<Product, Product>
    {
        /*public override async Task<Product> Execute(WMSDatabaseContext context)
        {
            var product = await context.DeliveryProducts
                .Include(x => x.PalletLine)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            
            product. = Parameter.Amount;
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
            
            return product;
        }*/
        public override Task<Product> Execute(WMSDatabaseContext context)
        {
            throw new NotImplementedException();
        }
    }
}
