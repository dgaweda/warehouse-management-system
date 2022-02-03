using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery
{
    public class EditDeliveryRequest :  CurrentUserContext, IRequest<EditDeliveryResponse>
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }

    }
}
