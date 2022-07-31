using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.ProductRepository;

namespace DataAccess.CQRS.Command.ProductCommands
{
    public class RemoveProductCommand : CommandBase<Product, IProductRepository>
    {
        public override async Task Execute(IProductRepository productRepository)
        {
            await productRepository.DeleteAsync(Parameter.Id);
        }
    }
}
