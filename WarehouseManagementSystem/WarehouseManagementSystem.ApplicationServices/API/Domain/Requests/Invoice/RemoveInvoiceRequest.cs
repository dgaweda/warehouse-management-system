using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice
{
    public class RemoveInvoiceRequest : IRequest<RemoveInvoiceResponse>
    {
        public int InvoiceId { get; set; }
    }
}