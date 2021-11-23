using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.LocationCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationService
{
    public class EditLocationCurrentAmountHandler :
        CommandHandler<EditLocationCurrentAmountRequest, EditLocationCurrentAmountResponse, Location, Domain.Models.Location, EditLocationCurrentAmountCommand>,
        IRequestHandler<EditLocationCurrentAmountRequest, EditLocationCurrentAmountResponse>
    {
        public EditLocationCurrentAmountHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }
        public async Task<EditLocationCurrentAmountResponse> Handle(EditLocationCurrentAmountRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
