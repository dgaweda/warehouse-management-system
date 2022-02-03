using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DepartureCommands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureService
{
    public class EditDepartureStateHandler :
        CommandHandler<EditDepartureStateRequest, EditDepartureStateResponse, Departure, Domain.Models.Departure, EditDepartureStateCommand>,
        IRequestHandler<EditDepartureStateRequest, EditDepartureStateResponse>
    {
        public EditDepartureStateHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {

        }
        public async Task<EditDepartureStateResponse> Handle(EditDepartureStateRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
