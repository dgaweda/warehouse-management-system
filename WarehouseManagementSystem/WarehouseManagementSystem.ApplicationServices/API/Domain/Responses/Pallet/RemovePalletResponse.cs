using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet
{
    public class RemovePalletResponse : ResponseBase<Unit>
    {
        public RemovePalletResponse()
        {
            Response = Unit.Value;
        }
    }
}
