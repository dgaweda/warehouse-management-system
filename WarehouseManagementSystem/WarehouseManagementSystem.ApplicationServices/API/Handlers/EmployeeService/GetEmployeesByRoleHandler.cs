using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.EmployeeService
{
    public class GetEmployeesByRoleHandler : IRequestHandler<GetEmployeesByRoleRequest, GetEmployeesByRoleResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;
        public GetEmployeesByRoleHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<GetEmployeesByRoleResponse> Handle(GetEmployeesByRoleRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeByRoleQuery()
            {
                RoleName = request.RoleName
            };
            var employeeModel = await _queryExecutor.Execute(query);
            var domainEmployeeModel = _mapper.Map<List<Domain.Models.Employee>>(employeeModel);
            var response = new GetEmployeesByRoleResponse()
            {
                Data = domainEmployeeModel
            };
            return response;
        }
    }
}
