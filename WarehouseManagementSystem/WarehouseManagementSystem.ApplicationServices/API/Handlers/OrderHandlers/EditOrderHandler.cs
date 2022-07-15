using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.OrderCommands;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderHandlers
{
    public class EditOrderHandler:
        CommandHandler<EditOrderCommand, Order, IOrderRepository>,
        IRequestHandler<EditOrderRequest, EditOrderResponse>
    {
        public EditOrderHandler(IMapper mapper, IOrderRepository repositoryService,
            IValidator<EditOrderRequest> validator)
            : base(mapper, repositoryService)
        {
        }

        public async Task<EditOrderResponse> Handle(EditOrderRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditOrderResponse()
            {
                Response = request.Id
            };
        }
    }
}