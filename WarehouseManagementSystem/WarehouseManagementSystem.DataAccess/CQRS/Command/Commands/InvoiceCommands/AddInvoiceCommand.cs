using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Extensions;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands
{
    public class AddInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(IRepository<Invoice> invoiceRepository)
        {
            var invoices = await invoiceRepository.Entity.ToListAsync();
            Parameter.SetInvoiceNumber(invoices);

            await invoiceRepository.Add(Parameter);

            return Parameter;
        }
    }
}
