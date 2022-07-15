using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.ProductRepository;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class RemoveProductCommand : CommandBase<Product, IProductRepository>
    {
        public override async Task Execute(IProductRepository productRepository)
        {
            await productRepository.DeleteAsync(Parameter.Id);
        }
    }
}
