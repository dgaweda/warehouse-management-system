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
    public class EditOrderHandler:
        CommandHandler<EditOrderRequest, EditOrderResponse, Order, Domain.Models.Order, EditOrderCommand>,
        IRequestHandler<EditOrderRequest, EditOrderResponse>
    {
        public EditOrderHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<EditOrderResponse> Handle(EditOrderRequest request, CancellationToken cancellationToken) =>
            await PrepareResponse(request);
    }
}