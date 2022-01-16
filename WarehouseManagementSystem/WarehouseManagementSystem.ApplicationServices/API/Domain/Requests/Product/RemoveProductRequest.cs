using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct
{
    public class RemoveProductRequest : CurrentUserContext, IRequest<RemoveProductResponse>
    {
        public int Id { get; set; }
    }
}
