using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class EditInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(WMSDatabaseContext context)
        {
            var invoices = await context.Invoices.ToListAsync();

            Parameter.SetInvoiceNumber(invoices);

            await context.UpdateRecord(Parameter);
            return Parameter;
        }
    }
}
