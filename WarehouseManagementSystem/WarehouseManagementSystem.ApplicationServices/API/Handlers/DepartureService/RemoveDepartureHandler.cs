using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DepartureCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureService
{
    public class RemoveDepartureHandler : 
        CommandHandler<RemoveDepartureRequest, RemoveDepartureResponse, Departure, Domain.Models.Departure, RemoveDepartureCommand>,
        IRequestHandler<RemoveDepartureRequest, RemoveDepartureResponse>
    {
        public RemoveDepartureHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {

        }
        public async Task<RemoveDepartureResponse> Handle(RemoveDepartureRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
