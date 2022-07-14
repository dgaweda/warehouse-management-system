using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location
{
    public class RemoveLocationResponse : ResponseBase<Unit>
    {
        public RemoveLocationResponse()
        {
            Response = Unit.Value;
        }
    }
}
