using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.PalletCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class SetPalletDestinationHandler : 
        CommandHandler<SetPalletDestinationRequest, SetPalletDestinationResponse, Pallet, Domain.Models.PalletDto, SetPalletDestinationCommand>,
        IRequestHandler<SetPalletDestinationRequest, SetPalletDestinationResponse>
    {
        public SetPalletDestinationHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Pallet> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<SetPalletDestinationResponse> Handle(SetPalletDestinationRequest request, CancellationToken cancellationToken) => await GetResponse(request);
    }
}
