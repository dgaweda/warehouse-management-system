using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets
{
    public class GetProductsByPalletIdRequest : IRequest<GetProductsByPalletIdResponse>
    {
        public int PalletId { get; set; }
    }
}