using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role
{
    public class AddRoleRequest : UserRequestBase, IRequest<AddRoleResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
    }
}
