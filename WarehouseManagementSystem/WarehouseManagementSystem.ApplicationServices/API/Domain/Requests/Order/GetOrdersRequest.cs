using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class GetOrdersRequest : CurrentUserContext, IRequest<GetOrdersResponse>
    {
    }
}
