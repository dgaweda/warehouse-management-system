using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.OrderLineCommands;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.OrderLine;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.OrderLine;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderLineHandlers
{
    public class AddOrderLineHandler:
        CommandHandler<AddOrderLineRequest, AddOrderLineResponse, DataAccess.Entities.OrderLine,OrderLine, AddOrderLineCommand>,
        IRequestHandler<AddOrderLineRequest, AddOrderLineResponse>
    {
        public AddOrderLineHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<AddOrderLineResponse> Handle(AddOrderLineRequest request, CancellationToken cancellationToken) =>
            await PrepareResponse(request);
    }
}