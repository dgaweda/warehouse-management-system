using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class GetOrdersRequest : IRequest<GetOrdersResponse>
    {
    }
}