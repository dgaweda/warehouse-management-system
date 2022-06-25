using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class GetOrdersRequest : IRequest<GetOrdersResponse>
    {
        public int? Id { get; set; }
    }
}