using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.RoleCommands;
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
    public class RemoveRoleHandler : IRequestHandler<RemoveRoleRequest, RemoveRoleResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public RemoveRoleHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<RemoveRoleResponse> Handle(RemoveRoleRequest request, CancellationToken cancellationToken)
        {
            var command = new RemoveRoleCommand()
            {
                Parameter = request.RoleId
            };
            var removedRole = await _commandExecutor.Execute(command);
            var domainRoleModel = _mapper.Map<API.Domain.Models.Role>(removedRole);
            var response = new RemoveRoleResponse()
            {
                Data = domainRoleModel
            };
            return response;
        }
    }
}
