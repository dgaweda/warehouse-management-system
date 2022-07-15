using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.PalletCommands;
using DataAccess.Entities;
using DataAccess.Repository.PalletRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class SetPalletDestinationHandler : 
        CommandHandler<SetPalletDestinationCommand, Pallet, IPalletRepository>,
        IRequestHandler<SetPalletDestinationRequest, SetPalletDestinationResponse>
    {
        public SetPalletDestinationHandler(IMapper mapper, IPalletRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<SetPalletDestinationResponse> Handle(SetPalletDestinationRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new SetPalletDestinationResponse()
            {
                Response = request.Id
            };
        }
    }
}
