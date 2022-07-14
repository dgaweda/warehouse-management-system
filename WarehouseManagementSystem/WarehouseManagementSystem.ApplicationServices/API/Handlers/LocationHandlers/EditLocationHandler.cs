using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.LocationCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.LocationRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class EditLocationHandler :
        CommandHandler<EditLocationCommand, Location, ILocationRepository>,
        IRequestHandler<EditLocationRequest, EditLocationResponse>
    {
        public EditLocationHandler(IMapper mapper, ILocationRepository repositoryService)
            : base(mapper, repositoryService)
        {

        }
        public async Task<EditLocationResponse> Handle(EditLocationRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditLocationResponse()
            {
                Response = request.Id
            };
        }
    }
}
