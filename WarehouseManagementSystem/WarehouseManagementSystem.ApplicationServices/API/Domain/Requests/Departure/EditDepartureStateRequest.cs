using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class EditDepartureStateRequest : IRequest<EditDepartureStateResponse>
    {
        public int Id { get; set; }
        public StateType State { get; set; }
    }
}
