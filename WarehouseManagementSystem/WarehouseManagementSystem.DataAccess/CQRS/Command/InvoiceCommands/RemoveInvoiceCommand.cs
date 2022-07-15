using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.InvoiceRepository;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class RemoveInvoiceCommand : CommandBase<Invoice, IInvoiceRepository>
    {
        public override async Task Execute(IInvoiceRepository invoiceRepository)
        {
            await invoiceRepository.DeleteAsync(Parameter.Id);
        }
    }
}
