using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.EmployeeService
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

