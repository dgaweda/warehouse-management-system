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
    public class EditUserHandler : 
        CommandHandler<EditUserRequest, EditUserResponse, User, Domain.Models.User, EditUserCommand>,
        IRequestHandler<EditUserRequest, EditUserResponse>
    {
        public EditUserHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<EditUserResponse> Handle(EditUserRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}

