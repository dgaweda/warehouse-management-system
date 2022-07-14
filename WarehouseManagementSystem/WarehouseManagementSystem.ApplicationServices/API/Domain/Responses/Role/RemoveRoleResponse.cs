using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role
{
    public class RemoveRoleResponse : ResponseBase<Unit>
    {
        public RemoveRoleResponse()
        {
            Response = Unit.Value;
        }
    }
}
