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
    public class EditDeliveryProductAmountHandler :
    CommandHandler<EditDeliveryProductAmountRequest, EditDeliveryProductAmountResponse, DeliveryProduct, Domain.Models.DeliveryProduct, EditDeliveryProductAmountCommand>,
        IRequestHandler<EditDeliveryProductAmountRequest, EditDeliveryProductAmountResponse>
    {
        public EditDeliveryProductAmountHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<EditDeliveryProductAmountResponse> Handle(EditDeliveryProductAmountRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
