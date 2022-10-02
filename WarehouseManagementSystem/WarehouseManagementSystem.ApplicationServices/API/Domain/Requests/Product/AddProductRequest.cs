using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product
{
    public class AddProductRequest : RequestBase, IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Barcode { get; set; }
    }
}
