using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetPalletsByStatusRequest : CurrentUserContext, IRequest<GetPalletsByStatusResponse>
    {
        public PalletStatus PalletStatus { get; set; }
    }
}
