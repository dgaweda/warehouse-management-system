using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.ProductCommands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class SetProductLocationHandler :
        CommandHandler<SetProductLocationRequest, SetProductLocationResponse, Location, Domain.Models.Location, SetProductLocationCommand>,
        IRequestHandler<SetProductLocationRequest, SetProductLocationResponse>
    {
        public SetProductLocationHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<SetProductLocationResponse> Handle(SetProductLocationRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
