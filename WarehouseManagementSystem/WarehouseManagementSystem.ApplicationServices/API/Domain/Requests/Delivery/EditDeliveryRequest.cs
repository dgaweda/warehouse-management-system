using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery
{
    public class EditDeliveryRequest :  IRequest<EditDeliveryResponse>
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }

    }
}
