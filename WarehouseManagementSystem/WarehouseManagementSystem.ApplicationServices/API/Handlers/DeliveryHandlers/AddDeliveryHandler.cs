using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class AddDeliveryHandler :
        CommandHandler<AddDeliveryRequest, AddDeliveryResponse, Delivery, Domain.Models.DeliveryDto,
            AddDeliveryCommand>,
        IRequestHandler<AddDeliveryRequest, AddDeliveryResponse>
    {
        private readonly IValidator<GetDeliveriesRequest> _validator;
        public AddDeliveryHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<Delivery> repositoryService, IValidator<GetDeliveriesRequest> validator)
            : base(mapper, commandExecutor, repositoryService)
        {
            _validator = validator;
        }

        public async Task<AddDeliveryResponse> Handle(AddDeliveryRequest request, CancellationToken cancellationToken) => await GetResponse(request);
    }
}
