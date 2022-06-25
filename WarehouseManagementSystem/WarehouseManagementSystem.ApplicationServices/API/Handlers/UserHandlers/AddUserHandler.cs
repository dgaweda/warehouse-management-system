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
    public class AddUserHandler : 
        CommandHandler<AddUserRequest, AddUserResponse, DataAccess.Entities.User, Domain.Models.User, AddUserCommand>,
        IRequestHandler<AddUserRequest, AddUserResponse>
    {
        public AddUserHandler(ICommandExecutor commandExecutor, IMapper mapper, IRepository<User> repositoryService) : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            return await GetResponse(request);
        }
    }
}
