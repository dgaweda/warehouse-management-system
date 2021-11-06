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
            await SetInvoiceNumber(context);
            await context.Invoices.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }

        private async Task SetInvoiceNumber(WMSDatabaseContext context)
        {
            int i = 1;
            if (await SameInvoiceDataExistsIn(context))
                i++;

            Parameter.InvoiceNumber = "INV/" + i + "/" + Parameter.Provider + "/" + Parameter.InvoiceDate.Day + "/" + Parameter.InvoiceDate.Month + "/" + Parameter.InvoiceDate.Year;
        }

        private async Task<bool> SameInvoiceDataExistsIn(WMSDatabaseContext context)
        {
            var exists = false;
            await context.Invoices
                .ForEachAsync(property => 
                {
                    if (property.InvoiceDate == Parameter.InvoiceDate)
                        exists = true;
                });
            return exists;
        }
    }
}
