using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class RemoveOrderRequest: IRequest<RemoveOrderResponse>
    {
        public int Id { get; set; }
    }
}