using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.UserCommands;
using DataAccess.Entities;
using DataAccess.Repository.UserRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class EditUserHandler : 
        CommandHandler<EditUserCommand, User, IUserRepository>,
        IRequestHandler<EditUserRequest, EditUserResponse>
    {
        public EditUserHandler(IMapper mapper, IUserRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<EditUserResponse> Handle(EditUserRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditUserResponse()
            {
                Response = request.Id
            };
        }
    }
}

