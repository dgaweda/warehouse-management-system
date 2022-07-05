using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.DeliveryRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class AddDeliveryHandler :
        CommandHandler<AddDeliveryRequest, AddDeliveryResponse, Delivery, Domain.Models.DeliveryDto,
            AddDeliveryCommand, IDeliveryRepository>,
        IRequestHandler<AddDeliveryRequest, AddDeliveryResponse>
    {
        public AddDeliveryHandler(IMapper mapper, IRepository<Delivery> repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<AddDeliveryResponse> Handle(AddDeliveryRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
