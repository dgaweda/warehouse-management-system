using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee
{
    public class RemoveEmployeeRequest : IRequest<RemoveEmployeeResponse>
    {
        public int EmployeeId { get; set; }
    }
}
