﻿using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.PalletCommands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletService
{
    public class AddPalletHandler :
        CommandHandler<AddPalletRequest, AddPalletResponse, Pallet, Domain.Models.Pallet, AddPalletCommand>,
        IRequestHandler<AddPalletRequest, AddPalletResponse>
    {
        public AddPalletHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {

        }
        public async Task<AddPalletResponse> Handle(AddPalletRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
