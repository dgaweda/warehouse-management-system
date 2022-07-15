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
    public class RemovePalletHandler :
        CommandHandler<RemovePalletCommand, Pallet, IPalletRepository>,
        IRequestHandler<RemovePalletRequest, RemovePalletResponse>
    {

        public RemovePalletHandler(IMapper mapper, IPalletRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }
        public async Task<RemovePalletResponse> Handle(RemovePalletRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new RemovePalletResponse();
        }
    }
}
