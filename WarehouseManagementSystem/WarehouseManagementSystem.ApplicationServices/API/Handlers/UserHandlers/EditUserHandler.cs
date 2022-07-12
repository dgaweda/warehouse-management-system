using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class EditUserHandler : 
        CommandHandler<EditUserRequest, EditUserResponse, User, UserDto, EditUserCommand>,
        IRequestHandler<EditUserRequest, EditUserResponse>
    {
        public EditUserHandler(ICommandExecutor commandExecutor, IMapper mapper, IRepository<User> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<EditUserResponse> Handle(EditUserRequest request, CancellationToken cancellationToken)
        {
            return await HandleRequest(request);
        }
    }
}

