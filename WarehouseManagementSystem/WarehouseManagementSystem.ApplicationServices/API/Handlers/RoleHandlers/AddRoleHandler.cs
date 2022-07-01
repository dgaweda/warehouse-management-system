using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.RoleCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleHandlers
{
    public class AddRoleHandler : 
        CommandHandler<AddRoleRequest, AddRoleResponse, Role, Domain.Models.RoleDto, AddRoleCommand>,
        IRequestHandler<AddRoleRequest, AddRoleResponse> 
    {
        public AddRoleHandler(ICommandExecutor commandExecutor, IMapper mapper, IRepository<Role> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<AddRoleResponse> Handle(AddRoleRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
