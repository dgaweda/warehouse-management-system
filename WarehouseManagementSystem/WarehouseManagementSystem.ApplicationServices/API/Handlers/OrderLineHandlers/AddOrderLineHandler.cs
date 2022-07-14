using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.OrderLineCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.OrderLineRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.OrderLine;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.OrderLine;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderLineHandlers
{
    public class AddOrderLineHandler:
        CommandHandler<AddOrderLineCommand, OrderLine, IOrderLineRepository>,
        IRequestHandler<AddOrderLineRequest, AddOrderLineResponse>
    {
        public AddOrderLineHandler(IMapper mapper, IOrderLineRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<AddOrderLineResponse> Handle(AddOrderLineRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new AddOrderLineResponse()
            {
                Response = request.Id
            };
        }
    }
}