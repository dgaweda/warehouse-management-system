using AutoMapper;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.LocationCommands;
using DataAccess.Repository.LocationRepository;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class SetProductLocationHandler :
        CommandHandler<SetProductLocationCommand, Location, ILocationRepository>,
        IRequestHandler<SetProductLocationRequest, SetProductLocationResponse>
    {
        public SetProductLocationHandler(IMapper mapper, ILocationRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<SetProductLocationResponse> Handle(SetProductLocationRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new SetProductLocationResponse()
            {
                Response = request.Id
            };
        }
    }
}
