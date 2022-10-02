using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.InvoiceRepository;

namespace DataAccess.CQRS.Command.InvoiceCommands
{
    public class RemoveInvoiceCommand : CommandBase<Invoice, IInvoiceRepository>
    {
        public override async Task Execute(IInvoiceRepository invoiceRepository)
        {
            await invoiceRepository.DeleteAsync(Parameter.Id);
        }
    }
}
