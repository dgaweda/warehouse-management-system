using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryProductCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryProductService
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
