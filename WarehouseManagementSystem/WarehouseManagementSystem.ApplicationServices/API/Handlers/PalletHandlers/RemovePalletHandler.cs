using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.PalletCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class RemovePalletHandler :
        CommandHandler<RemovePalletRequest, RemovePalletResponse, Pallet, Domain.Models.PalletDto, RemovePalletCommand>,
        IRequestHandler<RemovePalletRequest, RemovePalletResponse>
    {

        public RemovePalletHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<Pallet> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {
        }
        public Task<RemovePalletResponse> Handle(RemovePalletRequest request, CancellationToken cancellationToken) => HandleRequest(request);
    }
}
