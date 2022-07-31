using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.RoleCommands;
using DataAccess.Entities;
using DataAccess.Repository.RoleRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleHandlers
{
    public class RemoveRoleHandler
        : CommandHandler<RemoveRoleCommand, Role, IRoleRepository>,
        IRequestHandler<RemoveRoleRequest, RemoveRoleResponse>
    {
        public RemoveRoleHandler(IMapper mapper, IRoleRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<RemoveRoleResponse> Handle(RemoveRoleRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new RemoveRoleResponse();
        }
    }
}
