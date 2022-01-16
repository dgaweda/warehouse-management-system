using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetOrdersRequest : IRequest<GetOrdersResponse>
    {
    }
}
