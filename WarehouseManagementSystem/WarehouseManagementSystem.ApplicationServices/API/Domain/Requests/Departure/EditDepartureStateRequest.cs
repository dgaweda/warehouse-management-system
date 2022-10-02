using DataAccess.Entities;
using DataAccess.Enums;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class EditDepartureStateRequest : RequestBase, IRequest<EditDepartureStateResponse>
    {
        public StateType State { get; set; }
    }
}
