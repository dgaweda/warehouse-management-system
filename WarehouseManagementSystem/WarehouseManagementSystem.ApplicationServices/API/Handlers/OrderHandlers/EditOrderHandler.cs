using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.OrderCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderHandlers
{
    public class EditOrderHandler:
        CommandHandler<EditOrderRequest, EditOrderResponse, Order, Domain.Models.OrderDto, EditOrderCommand>,
        IRequestHandler<EditOrderRequest, EditOrderResponse>
    {
        public EditOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Order> repositoryService,
            IValidator<EditOrderRequest> validator)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<EditOrderResponse> Handle(EditOrderRequest request, CancellationToken cancellationToken) =>
            await HandleRequest(request);
    }
}