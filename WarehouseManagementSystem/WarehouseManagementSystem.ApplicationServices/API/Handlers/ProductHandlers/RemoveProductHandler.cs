using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryProductCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductHandlers
{
    public class RemoveProductHandler :
        CommandHandler<RemoveProductRequest, RemoveProductResponse, Product, Domain.Models.ProductDto, RemoveProductCommand>,
        IRequestHandler<RemoveProductRequest, RemoveProductResponse>
    {
        public RemoveProductHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<Product> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<RemoveProductResponse> Handle(RemoveProductRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
