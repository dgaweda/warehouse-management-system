﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.LocationCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class EditLocationHandler :
        CommandHandler<EditLocationRequest, EditLocationResponse, Location, Domain.Models.LocationDto, EditLocationCommand>,
        IRequestHandler<EditLocationRequest, EditLocationResponse>
    {
        public EditLocationHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<Location> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {

        }
        public async Task<EditLocationResponse> Handle(EditLocationRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
