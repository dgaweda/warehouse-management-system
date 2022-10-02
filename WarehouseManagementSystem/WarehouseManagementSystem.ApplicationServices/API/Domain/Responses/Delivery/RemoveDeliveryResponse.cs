using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery
{
    public class RemoveDeliveryResponse : ResponseBase<Unit>
    {
        public RemoveDeliveryResponse()
        {
            Response = Unit.Value;
        }
    }
}
