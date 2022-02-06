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
    public class EditLocationHandler :
        CommandHandler<EditLocationRequest, EditLocationResponse, Location, Domain.Models.Location, EditLocationCommand>,
        IRequestHandler<EditLocationRequest, EditLocationResponse>
    {
        public EditLocationHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {

        }
        public async Task<EditLocationResponse> Handle(EditLocationRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
