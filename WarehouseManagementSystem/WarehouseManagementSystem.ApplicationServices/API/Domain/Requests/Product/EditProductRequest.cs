using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct
{
    public class EditProductRequest : UserRequestBase, IRequest<EditProductResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Barcode { get; set; }
    }
}
