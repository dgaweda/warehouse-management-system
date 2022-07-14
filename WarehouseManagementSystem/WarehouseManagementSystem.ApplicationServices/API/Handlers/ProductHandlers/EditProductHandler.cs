using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.DeliveryProductCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.ProductRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductHandlers
{
    public class EditProductHandler :
        CommandHandler<EditProductCommand, Product, IProductRepository>,
        IRequestHandler<EditProductRequest, EditProductResponse>
    {
        public EditProductHandler(IMapper mapper, IProductRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<EditProductResponse> Handle(EditProductRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditProductResponse()
            {
                Response = request.Id
            };
        }
    }
}
