using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryService
{
    public class EditDeliveryHandler
        : CommandHandler<EditDeliveryRequest, EditDeliveryResponse, Delivery, Domain.Models.Delivery, EditDeliveryCommand>,
        IRequestHandler<EditDeliveryRequest, EditDeliveryResponse>
    {
        public EditDeliveryHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public Task<EditDeliveryResponse> Handle(EditDeliveryRequest request, CancellationToken cancellationToken) => PrepareResponse(request);
    }
}
