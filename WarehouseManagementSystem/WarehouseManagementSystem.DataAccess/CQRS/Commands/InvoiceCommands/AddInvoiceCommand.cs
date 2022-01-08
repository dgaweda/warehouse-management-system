using DataAccess.CQRS.Commands.InvoiceCommands;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands
{
    public class AddInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(WMSDatabaseContext context)
        {
            var invoices = await context.Invoices.ToListAsync();

            Parameter.InvoiceNumber = Parameter
                .SetInvNumberId(invoices)
                .SetInvNumber(Parameter);

            return await context.AddRecord(Parameter);
        }
    }
}
