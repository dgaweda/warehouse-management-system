using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class RemoveInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(WMSDatabaseContext context)
        {
            var invoice = await context.Invoices.FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            context.Invoices.Remove(invoice);
            await context.SaveChangesAsync();
            return invoice;
        }
    }
}
