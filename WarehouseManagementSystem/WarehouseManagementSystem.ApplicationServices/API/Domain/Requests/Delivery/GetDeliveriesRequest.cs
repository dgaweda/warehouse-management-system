using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery
{
    public class GetDeliveriesRequest : CurrentUserContext, IRequest<GetDeliveriesResponse>
    {
        public string Name { get; set; }
    }
}
