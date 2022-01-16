using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet
{
    public class RemovePalletRequest : CurrentUserContext, IRequest<RemovePalletResponse>
    {
        public int PalletId { get; set; }
    }
}
