using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.ProductRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class RemoveProductCommand : CommandBase<Product, Product, IProductRepository>
    {
        public override async Task<Product> Execute(IProductRepository productRepository)
        {
            var product = await productRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await productRepository.DeleteAsync(Parameter.Id);
            return product;
        }
    }
}
