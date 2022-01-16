using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain
{
    public class GetRolesRequest : IRequest<GetRolesResponse>
    {
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}
