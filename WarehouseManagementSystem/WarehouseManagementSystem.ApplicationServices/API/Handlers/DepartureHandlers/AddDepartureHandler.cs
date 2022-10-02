using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.DepartureCommands;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class AddDepartureHandler :
        CommandHandler<AddDepartureCommand, Departure, IDepartureRepository>,
        IRequestHandler<AddDepartureRequest, AddDepartureResponse>
    {
        public AddDepartureHandler(IMapper mapper, IDepartureRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<AddDepartureResponse> Handle(AddDepartureRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new AddDepartureResponse()
            {
                Response = request.Id
            };
        }
    }
}
