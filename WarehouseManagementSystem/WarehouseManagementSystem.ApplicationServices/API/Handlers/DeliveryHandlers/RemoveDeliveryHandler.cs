using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryService
{
    public class RemoveDeliveryHandler 
        : CommandHandler<RemoveDeliveryRequest, RemoveDeliveryResponse, Delivery, Domain.Models.Delivery, RemoveDeliveryCommand>,
        IRequestHandler<RemoveDeliveryRequest, RemoveDeliveryResponse>
    {
        public RemoveDeliveryHandler(IMapper mapper, ICommandExecutor commandExecutor) :base(mapper, commandExecutor)
        {
        }

        public Task<RemoveDeliveryResponse> Handle(RemoveDeliveryRequest request, CancellationToken cancellationToken) => PrepareResponse(request);
    }
}
