using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.OrderCommands;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderHandlers
{
    public class AddOrderHandler: 
        CommandHandler<AddOrderRequest, AddOrderResponse, Order, Domain.Models.Order, AddOrderCommand>,
        IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        public AddOrderHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken) =>
            await PrepareResponse(request);
    }
}