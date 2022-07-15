using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Extensions;
using DataAccess.Repository.ProductRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class EditProductCommand : CommandBase<Product, IProductRepository>
    {
        public override async Task Execute(IProductRepository productRepository)
        {
            var product = await productRepository.Entity
                .Include(x => x.PalletLines)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            product.SetProperties(Parameter);
            await productRepository.UpdateAsync(product);
        }
    }
}
