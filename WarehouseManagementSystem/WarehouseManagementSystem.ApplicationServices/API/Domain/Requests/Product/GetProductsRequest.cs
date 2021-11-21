using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Barcode { get; set; }
    }
}
