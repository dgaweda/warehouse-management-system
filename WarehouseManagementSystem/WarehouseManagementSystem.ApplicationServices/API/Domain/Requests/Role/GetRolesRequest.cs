using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role
{
    public class GetRolesRequest : IRequest<GetRolesResponse>
    {
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}