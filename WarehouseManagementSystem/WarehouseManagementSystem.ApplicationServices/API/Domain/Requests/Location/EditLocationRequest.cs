using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class EditLocationRequest : IRequest<EditLocationResponse>
    {
        public int Id { get; set; }
        public int? MaxAmount { get; set; }
        public string Name { get; set; }
    }
}
