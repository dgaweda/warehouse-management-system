using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class RemoveDeliveryHandler 
        : CommandHandler<RemoveDeliveryRequest, RemoveDeliveryResponse, Delivery, Domain.Models.DeliveryDto, RemoveDeliveryCommand>,
        IRequestHandler<RemoveDeliveryRequest, RemoveDeliveryResponse>
    {
        public RemoveDeliveryHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Delivery> repositoryService) :base(mapper, commandExecutor, repositoryService)
        {
        }

        public Task<RemoveDeliveryResponse> Handle(RemoveDeliveryRequest request, CancellationToken cancellationToken) => GetResponse(request);
    }
}
