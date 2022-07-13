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
    public class RemoveInvoiceCommand : CommandBase<Invoice, Unit, IInvoiceRepository>
    {
        public override async Task<Unit> Execute(IInvoiceRepository invoiceRepository)
        {
            return await invoiceRepository.DeleteAsync(Parameter.Id);
        }
    }
}
