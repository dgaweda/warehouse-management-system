using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain
{
    public class GetRolesRequest : CurrentUserContext, IRequest<GetRolesResponse>
    {
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}
