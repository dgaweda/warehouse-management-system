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
    public class EditDeliveryProductHandler :
        CommandHandler<EditDeliveryProductRequest, EditDeliveryProductResponse, DeliveryProduct, Domain.Models.DeliveryProduct, EditDeliveryProductCommand>,
        IRequestHandler<EditDeliveryProductRequest, EditDeliveryProductResponse>
    {
        public EditDeliveryProductHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<EditDeliveryProductResponse> Handle(EditDeliveryProductRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
