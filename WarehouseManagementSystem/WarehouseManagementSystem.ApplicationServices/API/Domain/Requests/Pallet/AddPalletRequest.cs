using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet
{
    public class AddPalletRequest : RequestBase, IRequest<AddPalletResponse>
    {
        public string Barcode { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? DepartureId { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid? UserId { get; set; }
    }
}