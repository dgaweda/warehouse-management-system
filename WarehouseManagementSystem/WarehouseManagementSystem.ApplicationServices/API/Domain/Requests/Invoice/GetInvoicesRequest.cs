using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice
{
    public class GetInvoicesRequest : IRequest<GetInvoicesResponse>
    {
        public string InvoiceNumber { get; set; }
    }
}