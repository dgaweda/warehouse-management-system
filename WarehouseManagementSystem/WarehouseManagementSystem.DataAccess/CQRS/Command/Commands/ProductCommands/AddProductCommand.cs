using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class AddProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(IRepository<Product> productRepository)
        {
            await productRepository.Add(Parameter);
            return Parameter;
        }
    }
}
