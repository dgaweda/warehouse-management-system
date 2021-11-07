using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands
{
    public class AddInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(WMSDatabaseContext context)
        {
            var invoices = await context.Invoices.ToListAsync();

            SetInvoiceNumber(invoices);
            await context.Invoices.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }

        private void SetInvoiceNumber(List<Invoice> invoices)
        {
            var id = CountRepetitionOfDateAndProvider(invoices);

            Parameter.InvoiceNumber = $"INV/{id}/{Parameter.Provider}/{ Parameter.CreationDate.Day}/{Parameter.CreationDate.Month}/{Parameter.CreationDate.Year}";
        }

        private int CountRepetitionOfDateAndProvider(List<Invoice> invoices)
        {
            var id = 1;
            invoices.ForEach(invoice => 
                {
                    if (invoice.CreationDate.Date == Parameter.CreationDate.Date && invoice.Provider == Parameter.Provider)
                        id++;
                });
            return id;
        }
    }
}
