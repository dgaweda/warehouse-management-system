using DataAccess.CQRS.Commands.UserCommands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Users;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class CreateUserHandler :
        CommandHandler<CreateUserRequest, CreateUserResponse, User, Domain.Models.User, CreateUserCommand>,
        IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        public CreateUserHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return await PrepareResponse(request);
        }
            

    }
}
