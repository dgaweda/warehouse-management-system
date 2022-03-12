using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class AddOrderRequest: IRequest<AddOrderResponse>
    {
        public string Barcode { get; set; }
    }
}