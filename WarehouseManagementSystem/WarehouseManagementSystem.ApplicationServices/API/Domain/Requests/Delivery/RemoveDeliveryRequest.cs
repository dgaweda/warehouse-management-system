using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery
{
    public class RemoveDeliveryRequest : IRequest<RemoveDeliveryResponse>
    {
        public int DeliveryId { get; set; }
    }
}
