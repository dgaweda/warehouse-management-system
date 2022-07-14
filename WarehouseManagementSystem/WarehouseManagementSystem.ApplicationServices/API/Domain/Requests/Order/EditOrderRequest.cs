using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class EditOrderRequest: RequestBase, IRequest<EditOrderResponse>
    {
        public override Guid Id { get; set; }
        public string Barcode { get; set; }
        public OrderState OrderState { get; set; }
    }
}