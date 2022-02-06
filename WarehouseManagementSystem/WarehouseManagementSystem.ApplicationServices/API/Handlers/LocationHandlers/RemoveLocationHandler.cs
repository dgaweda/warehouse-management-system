using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.LocationCommands;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class RemoveLocationHandler :
        CommandHandler<RemoveLocationRequest, RemoveLocationResponse, Location, Domain.Models.Location, RemoveLocationCommand>,
        IRequestHandler<RemoveLocationRequest, RemoveLocationResponse>
    {
        public RemoveLocationHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<RemoveLocationResponse> Handle(RemoveLocationRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
