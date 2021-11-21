using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class AddDeliveryProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(WMSDatabaseContext context)
        {
            if (Parameter == null)
                throw new ArgumentNullException();

            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
