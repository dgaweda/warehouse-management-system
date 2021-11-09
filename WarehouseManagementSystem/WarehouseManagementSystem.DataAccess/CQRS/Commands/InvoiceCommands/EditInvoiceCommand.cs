using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class EditInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(WMSDatabaseContext context)
        {
            if (Parameter == null)
                throw new ArgumentNullException("Null parameter");

            var invoices = await context.Invoices.ToListAsync();
            var invoiceToDetach = invoices.FirstOrDefault(x => x.Id == Parameter.Id);

            new SetInvoiceNumber().Set(invoices, Parameter);

            context.Entry(invoiceToDetach).State = EntityState.Detached;
            context.Entry(Parameter).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var updatedRecord = await context.Invoices.Include(x => x.Delivery).FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            return updatedRecord;
        }
    }
}
