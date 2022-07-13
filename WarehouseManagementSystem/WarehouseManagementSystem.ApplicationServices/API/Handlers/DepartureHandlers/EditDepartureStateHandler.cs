﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.Commands.DepartureCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.DepartureRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class EditDepartureStateHandler :
        CommandHandler<EditDepartureStateCommand, Departure, IDepartureRepository, Departure>,
        IRequestHandler<EditDepartureStateRequest, EditDepartureStateResponse>
    {
        public EditDepartureStateHandler(IMapper mapper, IDepartureRepository repositoryService)
            : base(mapper, repositoryService)
        {

        }
        public async Task<EditDepartureStateResponse> Handle(EditDepartureStateRequest request, CancellationToken cancellationToken)
        {
            var result =  await HandleRequest(request);
            return new EditDepartureStateResponse()
            {
                Response = result.Id
            };
        }
    }
}
