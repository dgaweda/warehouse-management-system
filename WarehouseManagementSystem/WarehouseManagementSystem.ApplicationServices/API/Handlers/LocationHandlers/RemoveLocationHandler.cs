using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.LocationCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class RemoveLocationHandler :
        CommandHandler<RemoveLocationRequest, RemoveLocationResponse, Location, Domain.Models.LocationDto, RemoveLocationCommand>,
        IRequestHandler<RemoveLocationRequest, RemoveLocationResponse>
    {
        public RemoveLocationHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<Location> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<RemoveLocationResponse> Handle(RemoveLocationRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
