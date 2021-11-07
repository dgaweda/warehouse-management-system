using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.InvoiceQueries
{
    public class GetInvoicesHelper : IGetEntityHelper<Invoice>
    {
        public string InvoiceNumber { get; set; }

        public async Task<List<Invoice>> GetFilteredData(WMSDatabaseContext context)
        {
            var invoices = await context.Invoices
                .Include(x => x.Delivery)
                .ToListAsync();

            if (PropertiesAreEmpty())
                return invoices;
            else
                return SearchByInvoiceNumber(invoices);
        }

        private List<Invoice> SearchByInvoiceNumber(List<Invoice> invoices) => invoices.Where(invoice => invoice.InvoiceNumber.Contains(InvoiceNumber)).ToList();
        
        public bool PropertiesAreEmpty() => string.IsNullOrEmpty(InvoiceNumber);
    }
}
