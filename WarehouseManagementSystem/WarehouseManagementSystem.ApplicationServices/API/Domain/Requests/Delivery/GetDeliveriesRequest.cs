using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery
{
    public class GetDeliveriesRequest : IRequest<GetDeliveriesResponse>
    {
        public string Name { get; set; }
    }
}
