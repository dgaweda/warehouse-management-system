using DataAccess.Enums;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class GetLocationsByTypeRequest : RequestBase, IRequest<GetLocationsByTypeResponse>
    {
        public LocationType LocationType { get; set; }
    }
}