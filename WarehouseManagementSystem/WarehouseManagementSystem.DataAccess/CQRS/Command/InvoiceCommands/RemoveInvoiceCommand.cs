using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.InvoiceRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class RemoveInvoiceCommand : CommandBase<Invoice, Invoice, IInvoiceRepository>
    {
        public override async Task<Invoice> Execute(IInvoiceRepository invoiceRepository)
        {
            var invoice = await invoiceRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await invoiceRepository.DeleteAsync(Parameter.Id);
            return invoice;
        }
    }
}
