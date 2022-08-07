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
    public class AddUserHandler : 
        CommandHandler<AddUserCommand, User, IUserRepository>,
        IRequestHandler<AddUserRequest, AddUserResponse>
    {
        public AddUserHandler(IMapper mapper, IUserRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new AddUserResponse()
            {
                Response = request.Id
            };
        }
    }
}
