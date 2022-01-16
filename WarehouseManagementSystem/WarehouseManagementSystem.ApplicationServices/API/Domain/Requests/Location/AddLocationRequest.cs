using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class AddLocationRequest : IRequest<AddLocationResponse>
    {
        public int? ProductId { get; set; }
        public DataAccess.Entities.Type LocationType { get; set; }
        public string Name { get; set; }
        public int MaxAmount { get; set; }
    }
}
