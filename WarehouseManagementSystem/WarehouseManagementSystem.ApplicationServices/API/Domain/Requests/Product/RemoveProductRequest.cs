using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product
{
    public class RemoveProductRequest : RequestBase, IRequest<RemoveProductResponse>
    {
        public int Id { get; set; }
    }
}
