using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee
{
    public class GetEmployeesByRoleRequest : IRequest<GetEmployeesByRoleResponse>
    {
        public string RoleName { get; set; }
    }
}
