using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.ProductCommands;
using DataAccess.Entities;
using DataAccess.Repository.ProductRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductHandlers
{
    public class AddProductHandler :
        CommandHandler<AddProductCommand, Product, IProductRepository>,
        IRequestHandler<AddProductRequest, AddProductResponse>
    {
        public AddProductHandler(IMapper mapper, IProductRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new AddProductResponse()
            {
                Response = request.Id
            };
        }
    }
}
