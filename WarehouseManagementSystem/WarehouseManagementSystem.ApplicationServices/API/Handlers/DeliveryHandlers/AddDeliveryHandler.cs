using AutoMapper;
using DataAccess;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryService
{
    public class AddDeliveryHandler : 
        CommandHandler<AddDeliveryRequest, AddDeliveryResponse, Delivery, Domain.Models.Delivery, AddDeliveryCommand>, 
        IRequestHandler<AddDeliveryRequest, AddDeliveryResponse>
    {
        public AddDeliveryHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<AddDeliveryResponse> Handle(AddDeliveryRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
        }
}
