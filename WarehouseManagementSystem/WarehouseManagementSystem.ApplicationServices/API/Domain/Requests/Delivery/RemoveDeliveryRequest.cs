using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery
{
    public class RemoveDeliveryRequest : UserRequestBase, IRequest<RemoveDeliveryResponse>
    {
        public int DeliveryId { get; set; }
    }
}
