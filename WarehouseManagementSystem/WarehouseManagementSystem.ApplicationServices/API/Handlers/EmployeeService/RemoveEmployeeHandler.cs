using AutoMapper;
using DataAccess;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.EmployeeService
{
    public class RemoveEmployeeHandler : IRequestHandler<RemoveEmployeeRequest, RemoveEmployeeResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public RemoveEmployeeHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<RemoveEmployeeResponse> Handle(RemoveEmployeeRequest request, CancellationToken cancellationToken)
        {
            var command = new RemoveEmployeeCommand()
            {
                Parameter = request.EmployeeId
            };
            var removedEmployee = await _commandExecutor.Execute(command);
            var domainModel = _mapper.Map<API.Domain.Models.Employee>(removedEmployee);

            var response = new RemoveEmployeeResponse()
            {
                Data = domainModel
            };
            return response;
        }
    }
}
