using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet
{
    public class SetPalletDestinationRequest : RequestBase, IRequest<SetPalletDestinationResponse>
    {
        public override Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? DepartureId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? InvoiceId { get; set; }
    }
}