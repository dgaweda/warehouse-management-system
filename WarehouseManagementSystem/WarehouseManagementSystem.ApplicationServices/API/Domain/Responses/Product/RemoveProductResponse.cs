using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product
{
    public class RemoveProductResponse : ResponseBase<Unit>
    {
        public RemoveProductResponse()
        {
            Response = Unit.Value;
        }
    }
}
