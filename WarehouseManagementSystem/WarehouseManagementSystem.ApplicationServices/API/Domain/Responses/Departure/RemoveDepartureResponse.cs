using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure
{
    public class RemoveDepartureResponse : ResponseBase<Unit>
    {
        public RemoveDepartureResponse()
        {
            Response = Unit.Value;
        }
    }
}
