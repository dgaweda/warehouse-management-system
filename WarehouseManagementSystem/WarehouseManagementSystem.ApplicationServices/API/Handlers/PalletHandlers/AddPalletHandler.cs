﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.PalletCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class AddPalletHandler :
        CommandHandler<AddPalletRequest, AddPalletResponse, Pallet, Domain.Models.PalletDto, AddPalletCommand>,
        IRequestHandler<AddPalletRequest, AddPalletResponse>
    {
        public AddPalletHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Pallet> repositoryService,
            IValidator<AddPalletRequest> validator) 
            : base(mapper, commandExecutor, repositoryService)
        {

        }
        public async Task<AddPalletResponse> Handle(AddPalletRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
