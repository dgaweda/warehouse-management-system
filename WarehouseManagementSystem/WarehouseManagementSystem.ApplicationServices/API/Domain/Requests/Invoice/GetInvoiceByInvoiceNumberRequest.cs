using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice
{
    public class GetInvoiceByInvoiceNumberRequest : IRequest<GetInvoiceByInvoiceNumberResponse>
    {
        public string InvoiceNumber { get; set; }
    }
}