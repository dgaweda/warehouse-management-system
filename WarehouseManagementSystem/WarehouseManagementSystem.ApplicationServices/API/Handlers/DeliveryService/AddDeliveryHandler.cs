using AutoMapper;
using DataAccess;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DeliveryCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryService
{
    public class AddDeliveryHandler : IRequestHandler<AddDeliveryRequest, AddDeliveryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;

        public AddDeliveryHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }

        public async Task<AddDeliveryResponse> Handle(AddDeliveryRequest request, CancellationToken cancellationToken)
        {
            var requestData = _mapper.Map<Delivery>(request);
            var command = new AddDeliveryCommand()
            {
                Parameter = requestData
            };
            var entityModel = await _commandExecutor.Execute(command);
            var domainModel = _mapper.Map<Domain.Models.Delivery>(entityModel);
            var response = new AddDeliveryResponse()
            {
                Data = domainModel
            };
            return response;
        }
    }
}
