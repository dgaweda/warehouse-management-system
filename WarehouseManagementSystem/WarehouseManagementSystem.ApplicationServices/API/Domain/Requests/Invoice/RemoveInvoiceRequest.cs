using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice
{
    public class RemoveInvoiceRequest : RequestBase, IRequest<RemoveInvoiceResponse>
    {
        public Guid InvoiceId { get; set; }
    }
}