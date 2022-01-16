using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetLocationsRequest : IRequest<GetLocationsResponse>
    {
        public string Name { get; set; }
        public DataAccess.Entities.Type LocationType { get; set; }

    }
}
