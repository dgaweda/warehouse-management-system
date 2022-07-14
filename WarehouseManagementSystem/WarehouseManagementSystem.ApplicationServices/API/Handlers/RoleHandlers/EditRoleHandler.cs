using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.RoleCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.RoleRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleHandlers
{
    public class EditRoleHandler :
        CommandHandler<EditRoleCommand, Role, IRoleRepository>,
        IRequestHandler<EditRoleRequest, EditRoleResponse>
    {
        public EditRoleHandler(IMapper mapper, IRoleRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<EditRoleResponse> Handle(EditRoleRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditRoleResponse()
            {
                Response = request.Id
            };
        }
    }
}
