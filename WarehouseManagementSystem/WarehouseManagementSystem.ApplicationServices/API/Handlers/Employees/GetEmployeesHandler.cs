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
    public class GetEmployeesHandler : HandlerBase<GetEmployeesResponse>, IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IRepository<Employee> employeeRepository;
        private IEnumerable<Employee> employees;
        private IEnumerable<Domain.Models.Employee> domainEmployees;

        public GetEmployeesHandler(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var response = PrepareResponse();
            
            return Task.FromResult(response);
        }

        public override GetEmployeesResponse PrepareResponse()
        {
            PrepareDomainData();
            var response = new GetEmployeesResponse()
            {
                Data = domainEmployees.ToList()
            };

            return response;
        }

        public override void PrepareDomainData()
        {
            GetRepositoryEntity();
            domainEmployees = employees.Select(x => new Domain.Models.Employee()
            {
                Name = x.Name,
                LastName = x.LastName
            });
        }

        public override void GetRepositoryEntity()
        {
           employees = employeeRepository.GetAll();
        }
    }
}
