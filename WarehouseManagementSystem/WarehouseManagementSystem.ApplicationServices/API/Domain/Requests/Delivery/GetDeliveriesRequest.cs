using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetDeliveriesRequest : UserRequestBase, IRequest<GetDeliveriesResponse>
    {
        public string Name { get; set; }
    }
}
