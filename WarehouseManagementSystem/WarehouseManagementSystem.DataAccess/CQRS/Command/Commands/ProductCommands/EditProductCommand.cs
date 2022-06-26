using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Extensions;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class EditProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(IRepository<Product> productRepository)
        {
            var product = await productRepository.Entity
                .Include(x => x.PalletLines)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            product.SetProperties(Parameter);
            await productRepository.UpdateAsync(product);
            return product;
        }
    }
}
