﻿using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.SeniorityCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.SeniorityService
{
    public class EditSeniorityHandler : 
        CommandHandler<EditSeniorityRequest, EditSeniorityResponse, Seniority, Domain.Models.Seniority, EditSeniorityCommand>,
        IRequestHandler<EditSeniorityRequest, EditSeniorityResponse>
    {
        public EditSeniorityHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<EditSeniorityResponse> Handle(EditSeniorityRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}