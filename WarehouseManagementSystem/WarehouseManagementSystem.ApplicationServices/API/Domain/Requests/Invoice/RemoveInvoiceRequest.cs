using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice
{
    public class RemoveInvoiceRequest : IRequest<RemoveInvoiceResponse>
    {
        public int InvoiceId { get; set; }
    }
}
