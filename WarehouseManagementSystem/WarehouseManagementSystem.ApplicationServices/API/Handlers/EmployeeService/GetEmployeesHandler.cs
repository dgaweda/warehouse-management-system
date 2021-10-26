﻿using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using DataAccess.CQRS.Queries.EmployeeQueries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Employees
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;
        private readonly IGetEmployeesHelper _helper;
        public GetEmployeesHandler(IQueryExecutor queryExecutor, IMapper mapper, IGetEmployeesHelper helper)
        { 
            _queryExecutor = queryExecutor;
            _mapper = mapper;
            _helper = helper;
        }

        public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
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
            var query = new GetEmployeesQuery(data);

            var entityModel = await _queryExecutor.Execute(query);
            var domainModel = _mapper.Map<List<Domain.Models.Employee>>(entityModel);
            var response = new GetEmployeesResponse()
            {
                Data = domainModel
            };
            return response;
        }
    }
}
