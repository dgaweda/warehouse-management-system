using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryProductCommands;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductHandlers
{
    public class EditProductHandler :
        CommandHandler<EditProductRequest, EditProductResponse, Product, Domain.Models.Product, EditProductCommand>,
        IRequestHandler<EditProductRequest, EditProductResponse>
    {
        public EditProductHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<EditProductResponse> Handle(EditProductRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
