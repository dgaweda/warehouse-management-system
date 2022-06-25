using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class RemoveInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(IRepository<Invoice> invoiceRepository)
        {
            var invoice = await invoiceRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await invoiceRepository.Delete(Parameter.Id);
            return invoice;
        }
    }
}
