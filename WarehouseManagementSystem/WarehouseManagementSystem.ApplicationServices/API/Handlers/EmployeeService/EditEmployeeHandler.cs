using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.EmployeeService
{
    public class EditEmployeeHandler : IRequestHandler<EditEmployeeRequest, EditEmployeeResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public EditEmployeeHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<EditEmployeeResponse> Handle(EditEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<DataAccess.Entities.Employee>(request);
            var command = new EditEmployeeCommand() 
            { 
                Parameter = employee 
            };
            var updatedEmployee = await _commandExecutor.Execute(command);
            return new EditEmployeeResponse()
            {
                Data = _mapper.Map<Domain.Models.Employee>(updatedEmployee)
            };
        }
    }
}

