using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery
{
    public class RemoveDeliveryRequest : CurrentUserContext, IRequest<RemoveDeliveryResponse>
    {
        public int DeliveryId { get; set; }
    }
}
