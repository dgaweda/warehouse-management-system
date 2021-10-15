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
        private IRepository<Employee> employeeRepository { get; set; }
        private HandlerBase<Employee, Domain.Models.Employee, GetEmployeesResponse, GetEmployeesRequest> handler = new HandlerBase<Employee, Domain.Models.Employee, GetEmployeesResponse, GetEmployeesRequest>();
       
        public GetEmployeesHandler(IRepository<Employee> employeeRepository)
        {
           this.employeeRepository = employeeRepository;
        }

        public Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            PrepareDomainData();
            var response = CreateResponseFrom(request, cancellationToken);
            return response;
        }

        private void PrepareDomainData()
        {
            SetCurrentRepository(employeeRepository);
            GetAllCurrentRepositoryEntityData();
            SetDomainModel();
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
