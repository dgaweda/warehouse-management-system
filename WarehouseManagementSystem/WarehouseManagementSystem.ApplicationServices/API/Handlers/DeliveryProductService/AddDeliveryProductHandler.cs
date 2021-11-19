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
    public class AddDeliveryProductHandler :
        CommandHandler<AddDeliveryProductRequest, AddDeliveryProductResponse, DeliveryProduct, Domain.Models.DeliveryProduct, AddDeliveryProductCommand>,
        IRequestHandler<AddDeliveryProductRequest, AddDeliveryProductResponse>
    {
        public AddDeliveryProductHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<AddDeliveryProductResponse> Handle(AddDeliveryProductRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
