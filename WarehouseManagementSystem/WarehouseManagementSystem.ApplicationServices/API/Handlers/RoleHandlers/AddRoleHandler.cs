using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.RoleCommands;
using DataAccess.Entities;
using DataAccess.Repository.RoleRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleHandlers
{
    public class AddRoleHandler : 
        CommandHandler<AddRoleCommand, Role, IRoleRepository>,
        IRequestHandler<AddRoleRequest, AddRoleResponse> 
    {
        public AddRoleHandler(IMapper mapper, IRoleRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<AddRoleResponse> Handle(AddRoleRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new AddRoleResponse()
            {
                Response = request.Id
            };
        }
    }
}
