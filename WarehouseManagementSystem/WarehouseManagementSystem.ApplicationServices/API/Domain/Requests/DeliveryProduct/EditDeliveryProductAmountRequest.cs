using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct
{
    public class EditDeliveryProductAmountRequest : IRequest<EditDeliveryProductAmountResponse>
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
}
