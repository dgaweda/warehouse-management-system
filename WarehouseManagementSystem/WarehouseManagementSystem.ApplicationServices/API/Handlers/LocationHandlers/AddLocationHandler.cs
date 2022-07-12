using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.LocationCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class AddLocationHandler :
        CommandHandler<AddLocationRequest, AddLocationResponse, Location, Domain.Models.LocationDto, AddLocationCommand>,
        IRequestHandler<AddLocationRequest, AddLocationResponse>
    {
        public AddLocationHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<Location> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {

        }
        public async Task<AddLocationResponse> Handle(AddLocationRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
