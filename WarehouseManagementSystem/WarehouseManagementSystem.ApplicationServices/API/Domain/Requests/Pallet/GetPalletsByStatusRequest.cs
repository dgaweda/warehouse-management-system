using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetPalletsByStatusRequest : IRequest<GetPalletsByStatusResponse>
    {
        public Keys.PalletStatus PalletStatus { get; set; }
    }
}
