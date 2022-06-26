using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Command.Commands.DepartureCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class EditDepartureStateHandler :
        CommandHandler<EditDepartureStateRequest, EditDepartureStateResponse, Departure, Domain.Models.DepartureDTO, EditDepartureStateCommand>,
        IRequestHandler<EditDepartureStateRequest, EditDepartureStateResponse>
    {
        public EditDepartureStateHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Departure> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {

        }
        public async Task<EditDepartureStateResponse> Handle(EditDepartureStateRequest request, CancellationToken cancellationToken) => await GetResponse(request);
    }
}
