using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class RemoveDepartureRequest :  IRequest<RemoveDepartureResponse>
    {
        public int DepartureId { get; set; }
    }
}
