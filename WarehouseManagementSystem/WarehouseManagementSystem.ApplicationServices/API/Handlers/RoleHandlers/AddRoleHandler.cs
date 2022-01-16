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
    public class AddRoleHandler : 
        CommandHandler<AddRoleRequest, AddRoleResponse, Role, Domain.Models.Role, AddRoleCommand>,
        IRequestHandler<AddRoleRequest, AddRoleResponse> 
    {
        public AddRoleHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<AddRoleResponse> Handle(AddRoleRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
