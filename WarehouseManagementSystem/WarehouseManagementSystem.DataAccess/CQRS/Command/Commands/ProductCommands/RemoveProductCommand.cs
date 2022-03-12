using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class RemoveProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(WMSDatabaseContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await context.DeleteRecord(Parameter);
            return product;
        }
    }
}
