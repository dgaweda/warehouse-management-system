using DataAccess.Entities;
using DataAccess.Enums;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class GetDeparturesByStateRequest : RequestBase, IRequest<GetDeparturesByStateResponse>
    {
        public StateType State { get; set; }
    }
}