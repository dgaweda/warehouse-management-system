using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.RoleCommands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleService
{
    public class EditRoleHandler :
        CommandHandler<EditRoleRequest, EditRoleResponse, Role, Domain.Models.Role, EditRoleCommand>,
        IRequestHandler<EditRoleRequest, EditRoleResponse>
    {
        public EditRoleHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<EditRoleResponse> Handle(EditRoleRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
