using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class GetOrdersRequest : RequestBase, IRequest<GetOrdersResponse>
    {
    }
}