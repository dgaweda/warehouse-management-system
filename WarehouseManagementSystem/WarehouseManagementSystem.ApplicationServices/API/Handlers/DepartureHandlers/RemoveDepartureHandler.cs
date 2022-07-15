using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.DepartureCommands;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;


namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class RemoveDepartureHandler : 
        CommandHandler<RemoveDepartureCommand, Departure, IDepartureRepository>,
        IRequestHandler<RemoveDepartureRequest, RemoveDepartureResponse>
    {
        public RemoveDepartureHandler(IMapper mapper, IDepartureRepository repositoryService) 
            : base(mapper, repositoryService)
        {

        }
        public async Task<RemoveDepartureResponse> Handle(RemoveDepartureRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new RemoveDepartureResponse();
        }
    }
}
