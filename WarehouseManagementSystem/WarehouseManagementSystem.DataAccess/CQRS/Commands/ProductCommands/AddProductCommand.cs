using DataAccess.Entities;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class AddProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(WMSDatabaseContext context)
        {
            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
