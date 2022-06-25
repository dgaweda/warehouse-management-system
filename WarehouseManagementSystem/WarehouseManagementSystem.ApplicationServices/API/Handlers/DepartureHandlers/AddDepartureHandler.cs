using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.DepartureCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class AddDepartureHandler :
        CommandHandler<AddDepartureRequest, AddDepartureResponse, Departure, Domain.Models.Departure, AddDepartureCommand>,
        IRequestHandler<AddDepartureRequest, AddDepartureResponse>
    {
        public AddDepartureHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Departure> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public Task<AddDepartureResponse> Handle(AddDepartureRequest request, CancellationToken cancellationToken) => GetResponse(request);
    }
}
