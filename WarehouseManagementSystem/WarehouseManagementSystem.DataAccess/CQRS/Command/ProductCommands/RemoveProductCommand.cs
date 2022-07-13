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
    public class RemoveProductCommand : CommandBase<Product, Unit, IProductRepository>
    {
        public override async Task<Unit> Execute(IProductRepository productRepository)
        {
            return await productRepository.DeleteAsync(Parameter.Id);
        }
    }
}
