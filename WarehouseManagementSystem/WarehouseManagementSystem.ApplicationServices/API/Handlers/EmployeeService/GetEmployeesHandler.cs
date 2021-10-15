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
    public class GetEmployeesHandler : HandlerBase<Employee, Domain.Models.Employee, GetEmployeesResponse, GetEmployeesRequest>, IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>, IGetAll
    {
        private readonly IRepository<Employee> employeeRepository;
       
        public GetEmployeesHandler(IRepository<Employee> employeeRepository)
        {
           this.employeeRepository = employeeRepository;
        }

        public Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            PrepareCurrentRepositoryEntity(employeeRepository);
            SetDomainModel();

            var response = Service(request, cancellationToken);
            return response;
        }

        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.Employee()
            {
                Name = x.Name,
                LastName = x.LastName
            });
        }
    }
}
