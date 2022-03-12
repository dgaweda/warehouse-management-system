using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class RemoveInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(WMSDatabaseContext context)
        {
            var invoice = await context.Invoices.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await context.DeleteRecord(Parameter);
            return invoice;
        }
    }
}
