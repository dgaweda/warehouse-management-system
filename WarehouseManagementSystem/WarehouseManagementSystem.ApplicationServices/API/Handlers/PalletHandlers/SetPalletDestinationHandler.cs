using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.PalletCommands;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class SetPalletDestinationHandler : 
        CommandHandler<SetPalletDestinationRequest, SetPalletDestinationResponse, Pallet, Domain.Models.Pallet, SetPalletDestinationCommand>,
        IRequestHandler<SetPalletDestinationRequest, SetPalletDestinationResponse>
    {
        public SetPalletDestinationHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<SetPalletDestinationResponse> Handle(SetPalletDestinationRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
