using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery
{
    public class AddDeliveryRequest : IRequest<AddDeliveryResponse>
    {
        public DateTime Arrival { get; set; }
    }
}
