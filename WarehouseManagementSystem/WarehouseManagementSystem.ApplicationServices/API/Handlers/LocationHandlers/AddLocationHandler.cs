using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.LocationCommands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationService
{
    public class AddLocationHandler :
        CommandHandler<AddLocationRequest, AddLocationResponse, Location, Domain.Models.Location, AddLocationCommand>,
        IRequestHandler<AddLocationRequest, AddLocationResponse>
    {
        public AddLocationHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {

        }
        public async Task<AddLocationResponse> Handle(AddLocationRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
