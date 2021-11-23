using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.EmployeeService
{
    public class AddEmployeeHandler : 
        CommandHandler<AddEmployeeRequest, AddEmployeeResponse, DataAccess.Entities.Employee, Domain.Models.Employee, AddEmployeeCommand>,
        IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        public AddEmployeeHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
