using DataAccess.Enums;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet
{
    public class GetPalletsByStatusRequest : RequestBase, IRequest<GetPalletsByStatusResponse>
    {
        public PalletStatus PalletStatus { get; set; }
    }
}