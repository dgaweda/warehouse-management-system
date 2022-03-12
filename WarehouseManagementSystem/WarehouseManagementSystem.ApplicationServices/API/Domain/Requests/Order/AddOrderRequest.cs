using System.Collections.Generic;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.OrderLine;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class AddOrderRequest: IRequest<AddOrderResponse>
    {
        public string Barcode { get; set; }
        public List<AddOrderLineRequest> OrderLines { get; set; }
    }
}