using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets
{
    public class GetProductsByPalletIdRequest : IRequest<GetProductsByPalletIdResponse>
    {
        public int PalletId { get; set; }
    }
}
