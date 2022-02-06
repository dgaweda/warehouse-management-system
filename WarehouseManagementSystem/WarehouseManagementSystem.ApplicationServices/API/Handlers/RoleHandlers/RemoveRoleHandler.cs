using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.RoleCommands;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleHandlers
{
    public class RemoveRoleHandler
        : CommandHandler<RemoveRoleRequest, RemoveRoleResponse, Role, Domain.Models.Role, RemoveRoleCommand>,
        IRequestHandler<RemoveRoleRequest, RemoveRoleResponse>
    {
        public RemoveRoleHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<RemoveRoleResponse> Handle(RemoveRoleRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
