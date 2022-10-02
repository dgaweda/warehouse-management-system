using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice
{
    public class AddInvoiceRequest : RequestBase, IRequest<AddInvoiceResponse>
    {
        public string Provider { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ReceiptDateTime { get; set; }
        public Guid DeliveryId { get; set; }
    }
}