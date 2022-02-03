using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetProductsRequest : CurrentUserContext, IRequest<GetProductsResponse>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Barcode { get; set; }
    }
}
