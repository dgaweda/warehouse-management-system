using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet
{
    public class SetPalletDestinationRequest : IRequest<SetPalletDestinationResponse>
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? DepartureId { get; set; }
        public int? UserId { get; set; }
        public int? InvoiceId { get; set; }
    }
}