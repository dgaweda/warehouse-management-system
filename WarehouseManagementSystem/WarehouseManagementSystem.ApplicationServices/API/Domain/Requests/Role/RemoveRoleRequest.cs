using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role
{
    public class RemoveRoleRequest : IRequest<RemoveRoleResponse>
    {
        public int RoleId { get; set; }
    }
}