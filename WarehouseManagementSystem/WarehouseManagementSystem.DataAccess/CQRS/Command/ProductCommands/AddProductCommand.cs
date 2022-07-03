using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.ProductRepository;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class AddProductCommand : CommandBase<Product, Product, IProductRepository>
    {
        public override async Task<Product> Execute(IProductRepository productRepository)
        {
            return await productRepository.AddAsync(Parameter);
        }
    }
}
