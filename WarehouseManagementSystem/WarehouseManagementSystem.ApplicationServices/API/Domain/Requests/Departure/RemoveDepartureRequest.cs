using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class RemoveDepartureRequest :  IRequest<RemoveDepartureResponse>
    {
        public int DepartureId { get; set; }
    }
}
