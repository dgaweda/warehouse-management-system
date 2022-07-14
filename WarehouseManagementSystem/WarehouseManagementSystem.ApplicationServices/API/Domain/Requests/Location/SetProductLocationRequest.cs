using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class SetProductLocationRequest : RequestBase, IRequest<SetProductLocationResponse>
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}