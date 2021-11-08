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
    public class RemoveEmployeeHandler 
        :CommandHandler<RemoveEmployeeRequest, RemoveEmployeeResponse, Employee, Domain.Models.Employee, RemoveEmployeeCommand>,
        IRequestHandler<RemoveEmployeeRequest, RemoveEmployeeResponse>
    {
        public RemoveEmployeeHandler(ICommandExecutor commandExecutor, IMapper mapper) : base(mapper, commandExecutor)
        {
        }

        public async Task<RemoveEmployeeResponse> Handle(RemoveEmployeeRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
