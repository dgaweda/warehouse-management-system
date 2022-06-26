using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class RemoveProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(IRepository<Product> productRepository)
        {
            var product = await productRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await productRepository.DeleteAsync(Parameter.Id);
            return product;
        }
    }
}
