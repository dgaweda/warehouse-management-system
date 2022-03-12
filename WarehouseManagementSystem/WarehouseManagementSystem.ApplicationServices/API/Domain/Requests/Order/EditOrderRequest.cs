using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class EditOrderRequest: IRequest<EditOrderResponse>
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public OrderState OrderState { get; set; }
    }
}