using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.LocationCommands;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class RemoveLocationHandler :
        CommandHandler<RemoveLocationCommand, Location, ILocationRepository>,
        IRequestHandler<RemoveLocationRequest, RemoveLocationResponse>
    {
        public RemoveLocationHandler(IMapper mapper, ILocationRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<RemoveLocationResponse> Handle(RemoveLocationRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new RemoveLocationResponse();
        }
    }
}
