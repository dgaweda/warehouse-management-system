using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.EmployeeService
{
    public class GetEmployeesByRoleHandler : IRequestHandler<GetEmployeesByRoleRequest, GetEmployeesByRoleResponse>
    {
        private readonly IQueryExecutor _queryExecutor;

        public GetEmployeesByRoleHandler(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task<GetEmployeesByRoleResponse> Handle(GetEmployeesByRoleRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeByRoleQuery()
            {
                RoleName = request.RoleName
            };
            var employeeModel = await _queryExecutor.Execute(query);
            var response = new GetEmployeesByRoleResponse()
            {
                Data = employeeModel
            };
            return response;
        }
    }
}
