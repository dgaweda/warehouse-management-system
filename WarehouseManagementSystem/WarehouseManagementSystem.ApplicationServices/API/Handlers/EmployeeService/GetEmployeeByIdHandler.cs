using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.EmployeeService
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;
        public GetEmployeeByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeByIdQuery()
            {
                Id = request.EmployeeId
            };
            var employeeModel = await _queryExecutor.Execute(query);
            var domainEmployeeModel = _mapper.Map<Domain.Models.Employee>(employeeModel);
            var response = new GetEmployeeByIdResponse()
            {
                Data = domainEmployeeModel
            };
            return response;
        }
    }
}
