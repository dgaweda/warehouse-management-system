using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands
{
    public class AddInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(WMSDatabaseContext context)
        {
            var invoices = await context.Invoices.ToListAsync();
            Parameter.SetInvoiceNumber(invoices);

            await context.AddRecord(Parameter);

            return Parameter;
        }
    }
}
