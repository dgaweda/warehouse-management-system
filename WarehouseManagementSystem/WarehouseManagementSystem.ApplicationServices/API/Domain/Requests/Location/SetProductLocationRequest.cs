using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product
{
    public class SetProductLocationRequest : CurrentUserContext, IRequest<SetProductLocationResponse>
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
