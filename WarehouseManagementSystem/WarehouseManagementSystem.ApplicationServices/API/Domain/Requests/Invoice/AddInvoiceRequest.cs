using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice
{
    public class AddInvoiceRequest : IRequest<AddInvoiceResponse>
    {
        public string Provider { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceReceiptDate { get; set; }
        public int DeliveryId { get; set; }

    }
}
