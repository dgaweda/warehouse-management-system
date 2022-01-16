using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class EditLocationCurrentAmountRequest : IRequest<EditLocationCurrentAmountResponse>
    {
        public int Id { get; set; }
        public int CurrentAmount { get; set; }
    }
}
