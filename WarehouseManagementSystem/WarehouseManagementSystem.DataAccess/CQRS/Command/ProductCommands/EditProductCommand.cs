using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Extensions;
using DataAccess.Repository;
using DataAccess.Repository.ProductRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class EditProductCommand : CommandBase<Product, Product, IProductRepository>
    {
        public override async Task<Product> Execute(IProductRepository productRepository)
        {
            var product = await productRepository.Entity
                .Include(x => x.PalletLines)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            product.SetProperties(Parameter);
            return await productRepository.UpdateAsync(product);
        }
    }
}
