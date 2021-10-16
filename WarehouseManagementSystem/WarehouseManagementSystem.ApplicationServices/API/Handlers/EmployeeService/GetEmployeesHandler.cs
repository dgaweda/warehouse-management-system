using AutoMapper;
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


namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Employees
{
    public class GetEmployeesHandler : HandlerBase<Employee, Domain.Models.Employee, GetEmployeesResponse, GetEmployeesRequest>, IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IMapper mapper;
       
        public GetEmployeesHandler(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            SetDomainModel(employeeRepository, mapper);
            var response = PrepareResponse();
            return response;
        }
    }
}
