using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.LocationCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class EditLocationCurrentAmountHandler :
        CommandHandler<EditLocationCurrentAmountRequest, EditLocationCurrentAmountResponse, Location, Domain.Models.LocationDto, EditLocationCurrentAmountCommand>,
        IRequestHandler<EditLocationCurrentAmountRequest, EditLocationCurrentAmountResponse>
    {
        public EditLocationCurrentAmountHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Location> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {
        }
        public async Task<EditLocationCurrentAmountResponse> Handle(EditLocationCurrentAmountRequest request, CancellationToken cancellationToken) => await GetResponse(request);
    }
}
