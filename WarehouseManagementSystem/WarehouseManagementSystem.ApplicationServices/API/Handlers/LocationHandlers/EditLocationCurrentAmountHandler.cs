using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.LocationCommands;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class EditLocationCurrentAmountHandler :
        CommandHandler<EditLocationCurrentAmountCommand, Location, ILocationRepository>,
        IRequestHandler<EditLocationCurrentAmountRequest, EditLocationCurrentAmountResponse>
    {
        public EditLocationCurrentAmountHandler(IMapper mapper, ILocationRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }
        public async Task<EditLocationCurrentAmountResponse> Handle(EditLocationCurrentAmountRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditLocationCurrentAmountResponse()
            {
                Response = request.Id
            };
        }
    }
}
