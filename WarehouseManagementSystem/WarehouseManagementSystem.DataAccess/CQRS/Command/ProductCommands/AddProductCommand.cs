using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.ProductRepository;

namespace DataAccess.CQRS.Command.ProductCommands
{
    public class AddProductCommand : CommandBase<Product, IProductRepository>
    {
        public override async Task Execute(IProductRepository productRepository)
        {
            await productRepository.AddAsync(Parameter);
        }
    }
}
