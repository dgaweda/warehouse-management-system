using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.ProductRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
