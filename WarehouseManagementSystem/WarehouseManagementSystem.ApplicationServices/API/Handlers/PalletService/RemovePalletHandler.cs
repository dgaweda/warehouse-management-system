﻿using AutoMapper;
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
    public class RemovePalletHandler :
        CommandHandler<RemovePalletRequest, RemovePalletResponse, Pallet, Domain.Models.Pallet, RemovePalletCommand>,
        IRequestHandler<RemovePalletRequest, RemovePalletResponse>
    {

        public RemovePalletHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }
        public Task<RemovePalletResponse> Handle(RemovePalletRequest request, CancellationToken cancellationToken) => PrepareResponse(request);
    }
}
