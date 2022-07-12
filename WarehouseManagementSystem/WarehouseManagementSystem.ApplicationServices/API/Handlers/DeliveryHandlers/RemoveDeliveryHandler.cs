using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using DataAccess.Repository.DeliveryRepository;
using DataAccess.Repository.DeliveryRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class RemoveDeliveryHandler 
        : CommandHandler<RemoveDeliveryCommand, Delivery, IDeliveryRepository>,
        IRequestHandler<RemoveDeliveryRequest, RemoveDeliveryResponse>
    {
        public RemoveDeliveryHandler(IMapper mapper, IDeliveryRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<RemoveDeliveryResponse> Handle(RemoveDeliveryRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new RemoveDeliveryResponse()
            {
                Response = Unit.Value
            };
        }
    }
}
