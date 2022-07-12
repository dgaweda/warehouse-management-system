using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.DepartureCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class RemoveDepartureHandler : 
        CommandHandler<RemoveDepartureRequest, RemoveDepartureResponse, Departure, DepartureDto, RemoveDepartureCommand>,
        IRequestHandler<RemoveDepartureRequest, RemoveDepartureResponse>
    {
        public RemoveDepartureHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Departure> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {

        }
        public async Task<RemoveDepartureResponse> Handle(RemoveDepartureRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
