using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.DeliveryProductCommands;
using DataAccess.Entities;
using DataAccess.Repository.ProductRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductHandlers
{
    public class RemoveProductHandler :
        CommandHandler<RemoveProductCommand, Product, IProductRepository>,
        IRequestHandler<RemoveProductRequest, RemoveProductResponse>
    {
        public RemoveProductHandler(IMapper mapper, IProductRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<RemoveProductResponse> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new RemoveProductResponse();
        }
    }
}
