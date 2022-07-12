using AutoMapper;
using DataAccess.CQRS.Commands.ProductCommands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Repository;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class SetProductLocationHandler :
        CommandHandler<SetProductLocationRequest, SetProductLocationResponse, Location, Domain.Models.LocationDto, SetProductLocationCommand>,
        IRequestHandler<SetProductLocationRequest, SetProductLocationResponse>
    {
        public SetProductLocationHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<Location> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<SetProductLocationResponse> Handle(SetProductLocationRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
