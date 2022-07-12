using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class GetDeparturesByStateRequest : IRequest<GetDeparturesByStateResponse>
    {
        public StateType State { get; set; }
    }
}