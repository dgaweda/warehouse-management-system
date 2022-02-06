using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product
{
    public class GetProductsRequest :  IRequest<GetProductsResponse>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Barcode { get; set; }
    }
}
