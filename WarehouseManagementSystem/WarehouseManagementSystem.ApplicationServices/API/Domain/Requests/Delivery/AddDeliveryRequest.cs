using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery
{
    public class AddDeliveryRequest : RequestBase, IRequest<AddDeliveryResponse>
    {
        public DateTime Arrival { get; set; }
    }
}
