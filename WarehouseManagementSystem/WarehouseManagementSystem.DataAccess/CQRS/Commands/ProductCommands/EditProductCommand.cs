using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.VisualBasic.CompilerServices;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class EditProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(WMSDatabaseContext context)
        {
            var product = await context.Products
                .Include(x => x.PalletLines)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            product.SetProperties(Parameter);
            await context.UpdateRecord(product);

            return product;
        }
    }
}
