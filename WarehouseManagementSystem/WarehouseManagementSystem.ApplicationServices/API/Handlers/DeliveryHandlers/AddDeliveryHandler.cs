using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.DeliveryCommands;
using DataAccess.Entities;
using DataAccess.Repository.DeliveryRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class AddDeliveryHandler :
        CommandHandler<AddDeliveryCommand, Delivery, IDeliveryRepository>,
        IRequestHandler<AddDeliveryRequest, AddDeliveryResponse>
    {
        public AddDeliveryHandler(IMapper mapper, IDeliveryRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<AddDeliveryResponse> Handle(AddDeliveryRequest request, CancellationToken cancellationToken)
        {
            var result = await HandleRequest(request);
            return new AddDeliveryResponse()
            {
                Response = result.Id
            };
        }
    }
}
