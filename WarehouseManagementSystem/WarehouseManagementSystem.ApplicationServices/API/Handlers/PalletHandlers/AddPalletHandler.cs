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
    public class AddPalletHandler :
        CommandHandler<AddPalletCommand, Pallet, IPalletRepository>,
        IRequestHandler<AddPalletRequest, AddPalletResponse>
    {
        public AddPalletHandler(IMapper mapper, IPalletRepository repositoryService) 
            : base(mapper, repositoryService)
        {

        }
        public async Task<AddPalletResponse> Handle(AddPalletRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new AddPalletResponse()
            {
                Response = request.Id
            };
        }
    }
}
