using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.PalletCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletService
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
