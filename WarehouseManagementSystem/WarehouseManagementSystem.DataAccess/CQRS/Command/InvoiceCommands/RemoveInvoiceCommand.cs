using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.InvoiceRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
