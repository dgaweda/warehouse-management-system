using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Handlers.Base;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Employees
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IHandlerBase<GetEmployeesQuery, Domain.Models.Employee, GetEmployeesResponse, List<Employee>> handler;

        public GetEmployeesHandler(IHandlerBase<GetEmployeesQuery, Domain.Models.Employee, GetEmployeesResponse, List<Employee>> handler)
        {
            this.handler = handler;
        }

        public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var response = await handler.PrepareResponseAndQuery();
            return response;
        }
    }
}
