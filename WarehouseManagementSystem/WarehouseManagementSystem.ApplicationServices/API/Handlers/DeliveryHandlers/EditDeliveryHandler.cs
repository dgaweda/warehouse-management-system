﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class EditDeliveryHandler
        : CommandHandler<EditDeliveryRequest, EditDeliveryResponse, Delivery, Domain.Models.Delivery, EditDeliveryCommand>,
        IRequestHandler<EditDeliveryRequest, EditDeliveryResponse>
    {
        public EditDeliveryHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Delivery> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public Task<EditDeliveryResponse> Handle(EditDeliveryRequest request, CancellationToken cancellationToken) => GetResponse(request);
    }
}
