using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role
{
    public class AddRoleRequest : IRequest<AddRoleResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
    }
}