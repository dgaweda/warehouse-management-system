using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Extensions;

namespace DataAccess.CQRS.Queries.InvoiceQueries
{
    public class GetInvoicesQuery : QueryBase<List<Invoice>>
    {
        public string InvoiceNumber { get; set; }

        public override async Task<List<Invoice>> Execute(WMSDatabaseContext context)
        {
            var invoices = await context.Invoices
                .Include(x => x.Delivery)
                .ToListAsync();

            return invoices.FilterByInvoiceNumber(InvoiceNumber);
        }
    }
}
