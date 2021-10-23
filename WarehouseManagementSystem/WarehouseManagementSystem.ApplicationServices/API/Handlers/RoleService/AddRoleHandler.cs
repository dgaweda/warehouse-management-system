using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.RoleCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleService
{
    public class AddRoleHandler : IRequestHandler<AddRoleRequest, AddRoleResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddRoleHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddRoleResponse> Handle(AddRoleRequest request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request);
            var command = new AddRoleCommand()
            {
                Parameter = role
            };
            var addedRole = await _commandExecutor.Execute(command);
            var response = new AddRoleResponse()
            {
                Data = addedRole
            };
            return response;
        }
    }
}
