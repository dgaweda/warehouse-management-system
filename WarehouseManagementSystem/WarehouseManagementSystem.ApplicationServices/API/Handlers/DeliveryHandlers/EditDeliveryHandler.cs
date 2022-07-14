using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using DataAccess.Repository.DeliveryRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class EditDeliveryHandler
        : CommandHandler<EditDeliveryCommand, Delivery, IDeliveryRepository>,
        IRequestHandler<EditDeliveryRequest, EditDeliveryResponse>
    {
        public EditDeliveryHandler(IMapper mapper, IDeliveryRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<EditDeliveryResponse> Handle(EditDeliveryRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditDeliveryResponse()
            {
                Response = request.Id
            };
        }
    }
}
