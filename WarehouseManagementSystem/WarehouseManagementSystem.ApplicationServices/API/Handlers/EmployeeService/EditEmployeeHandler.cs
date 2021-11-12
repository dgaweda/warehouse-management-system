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
    public class EditEmployeeHandler : 
        CommandHandler<EditEmployeeRequest, EditEmployeeResponse, Employee, Domain.Models.Employee, EditEmployeeCommand>,
        IRequestHandler<EditEmployeeRequest, EditEmployeeResponse>
    {
        public EditEmployeeHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<EditEmployeeResponse> Handle(EditEmployeeRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}

