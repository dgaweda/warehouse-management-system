using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.OrderLine;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.OrderLine
{
    public class AddOrderLineRequest: RequestBase, IRequest<AddOrderLineResponse>
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}