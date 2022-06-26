using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class RemoveUserHandler 
        :CommandHandler<RemoveUserRequest, RemoveUserResponse, User, Domain.Models.UserDTO, RemoveUserCommand>,
        IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        public RemoveUserHandler(ICommandExecutor commandExecutor, IMapper mapper, IRepository<User> repositoryService) : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken) => await GetResponse(request);
    }
}
