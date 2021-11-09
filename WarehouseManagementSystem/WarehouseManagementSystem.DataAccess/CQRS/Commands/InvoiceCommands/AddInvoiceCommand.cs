using DataAccess.CQRS.Commands.InvoiceCommands;
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

            new SetInvoiceNumber().Set(invoices, Parameter);
            await context.Invoices.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
