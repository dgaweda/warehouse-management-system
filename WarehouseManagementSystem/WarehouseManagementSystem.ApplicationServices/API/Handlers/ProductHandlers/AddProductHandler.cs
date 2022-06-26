using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryProductCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductHandlers
{
    public class AddProductHandler :
        CommandHandler<AddProductRequest, AddProductResponse, Product, Domain.Models.ProductDto, AddProductCommand>,
        IRequestHandler<AddProductRequest, AddProductResponse>
    {
        public AddProductHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Product> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken) => await GetResponse(request);
    }
}
