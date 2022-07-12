using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.OrderLineCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.OrderLine;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.OrderLine;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderLineHandlers
{
    public class AddOrderLineHandler:
        CommandHandler<AddOrderLineRequest, AddOrderLineResponse, OrderLine, OrderLineDto, AddOrderLineCommand>,
        IRequestHandler<AddOrderLineRequest, AddOrderLineResponse>
    {
        public AddOrderLineHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<OrderLine> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<AddOrderLineResponse> Handle(AddOrderLineRequest request, CancellationToken cancellationToken) =>
            await HandleRequest(request);
    }
}