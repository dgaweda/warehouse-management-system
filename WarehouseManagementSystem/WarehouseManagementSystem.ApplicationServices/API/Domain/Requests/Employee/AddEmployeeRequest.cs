using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class AddEmployeeRequest : IRequest<AddEmployeeResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }

    }
}
