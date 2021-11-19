using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct
{
    public class AddDeliveryProductRequest : IRequest<AddDeliveryProductResponse>
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Barcode { get; set; }
    }
}
