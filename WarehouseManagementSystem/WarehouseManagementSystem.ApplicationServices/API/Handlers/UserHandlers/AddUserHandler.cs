using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.EmployeeService
{
    public class AddUserHandler : 
        CommandHandler<AddUserRequest, AddUserResponse, DataAccess.Entities.User, Domain.Models.User, AddUserCommand>,
        IRequestHandler<AddUserRequest, AddUserResponse>
    {
        public AddUserHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            return await PrepareResponse(request);
        }
    }
}
