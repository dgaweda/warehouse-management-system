﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.OrderCommands;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderHandlers
{
    public class AddOrderHandler: 
        CommandHandler<AddOrderCommand, Order, IOrderRepository>,
        IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        public AddOrderHandler(IMapper mapper, IOrderRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new AddOrderResponse()
            {
                Response = request.Id
            };
        }
    }
}