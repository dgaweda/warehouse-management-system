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
    public class AddDepartureHandler :
        CommandHandler<AddDepartureRequest, AddDepartureResponse, Departure, Domain.Models.Departure, AddDepartureCommand>,
        IRequestHandler<AddDepartureRequest, AddDepartureResponse>
    {
        public AddDepartureHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public Task<AddDepartureResponse> Handle(AddDepartureRequest request, CancellationToken cancellationToken) => PrepareResponse(request);
    }
}
