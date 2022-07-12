using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.RoleCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleHandlers
{
    public class EditRoleHandler :
        CommandHandler<EditRoleRequest, EditRoleResponse, Role, Domain.Models.RoleDto, EditRoleCommand>,
        IRequestHandler<EditRoleRequest, EditRoleResponse>
    {
        public EditRoleHandler(ICommandExecutor commandExecutor, IMapper mapper, IRepository<Role> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<EditRoleResponse> Handle(EditRoleRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
