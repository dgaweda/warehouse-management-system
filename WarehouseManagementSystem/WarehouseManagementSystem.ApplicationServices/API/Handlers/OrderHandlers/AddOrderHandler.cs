using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.OrderCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderHandlers
{
    public class AddOrderHandler: 
        CommandHandler<AddOrderRequest, AddOrderResponse, Order, Domain.Models.Order, AddOrderCommand>,
        IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        public AddOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Order> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken) =>
            await GetResponse(request);
    }
}