using AutoMapper;
using DataAccess;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.EmployeeService
{
    public class RemoveUserHandler 
        :CommandHandler<RemoveUserRequest, RemoveUserResponse, User, Domain.Models.User, RemoveUserCommand>,
        IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        public RemoveUserHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
