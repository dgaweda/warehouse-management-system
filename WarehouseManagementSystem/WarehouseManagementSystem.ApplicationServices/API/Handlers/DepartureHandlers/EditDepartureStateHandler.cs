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
    public class EditDepartureStateHandler :
        CommandHandler<EditDepartureStateCommand, Departure, IDepartureRepository>,
        IRequestHandler<EditDepartureStateRequest, EditDepartureStateResponse>
    {
        public EditDepartureStateHandler(IMapper mapper, IDepartureRepository repositoryService)
            : base(mapper, repositoryService)
        {

        }
        public async Task<EditDepartureStateResponse> Handle(EditDepartureStateRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditDepartureStateResponse()
            {
                Response = request.Id
            };
        }
    }
}
