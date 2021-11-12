using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Employees
{
    public class GetEmployeesHandler :
        QueryHandler<GetEmployeesRequest, GetEmployeesResponse, GetEmployeesQuery, List<Employee>, List<Domain.Models.Employee>>,
        IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        public GetEmployeesHandler(IQueryExecutor queryExecutor, IMapper mapper) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override GetEmployeesQuery CreateQuery(GetEmployeesRequest request)
        {
            var data = new GetEmployeesHelper()
            {
                Age = request.Age,
                EmployeeId = request.EmployeeId,
                LastName = request.LastName,
                Name = request.Name,
                PESEL = request.PESEL,
                RoleName = request.RoleName
            };
            return new GetEmployeesQuery(data);
        }
    }
}
