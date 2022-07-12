using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.InvoiceRepository;

namespace DataAccess.CQRS.Queries.InvoiceQueries
{
    public class GetInvoiceByInvoiceNumberQuery : QueryBase<Invoice, IInvoiceRepository>
    {
        public string InvoiceNumber { get; set; }
        public override async Task<Invoice> Execute(IInvoiceRepository invoiceRepository)
        {
            return await invoiceRepository.GetInvoiceByInvoiceNumber(InvoiceNumber);
        }
    }
}