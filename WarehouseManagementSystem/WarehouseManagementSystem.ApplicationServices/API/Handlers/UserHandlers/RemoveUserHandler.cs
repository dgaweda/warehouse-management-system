using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class RemoveUserHandler 
        :CommandHandler<RemoveUserRequest, RemoveUserResponse, User, Domain.Models.User, RemoveUserCommand>,
        IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        public RemoveUserHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
