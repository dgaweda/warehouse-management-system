using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands;
using DataAccess.Entities;
using DataAccess.Repository.UserRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class RemoveUserHandler 
        :CommandHandler<RemoveUserCommand, User, IUserRepository>,
        IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        public RemoveUserHandler(IMapper mapper, IUserRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new RemoveUserResponse();
        }
    }
}
