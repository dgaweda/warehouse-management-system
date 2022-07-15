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
    public class AddLocationHandler :
        CommandHandler<AddLocationCommand, Location, ILocationRepository>,
        IRequestHandler<AddLocationRequest, AddLocationResponse>
    {
        public AddLocationHandler(IMapper mapper,
            ILocationRepository repositoryService) 
            : base(mapper, repositoryService)
        {

        }
        public async Task<AddLocationResponse> Handle(AddLocationRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new AddLocationResponse()
            {
                Response = request.Id
            };
        }
    }
}
