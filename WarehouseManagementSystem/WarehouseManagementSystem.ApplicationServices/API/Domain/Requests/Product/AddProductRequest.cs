using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct
{
    public class AddProductRequest : UserRequestBase, IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Barcode { get; set; }
    }
}
