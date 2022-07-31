using System.Threading;
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
    public class RemoveOrderHandler:
        CommandHandler<RemoveOrderCommand, Order, IOrderRepository>,
        IRequestHandler<RemoveOrderRequest, RemoveOrderResponse>
    {
        public RemoveOrderHandler(IMapper mapper, IOrderRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<RemoveOrderResponse> Handle(RemoveOrderRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new RemoveOrderResponse();
        }
    }
}