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
    public class EditRoleHandler : IRequestHandler<EditRoleRequest, EditRoleResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public EditRoleHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<EditRoleResponse> Handle(EditRoleRequest request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request);
            var command = new EditRoleCommand()
            {
                Parameter = role
            };
            var changedRole = await _commandExecutor.Execute(command);
            var response = new EditRoleResponse()
            {
                Data = changedRole
            };
            return response;
        }
    }
}
