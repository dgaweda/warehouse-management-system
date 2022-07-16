using System.Threading.Tasks;
using DataAccess.CQRS.Query;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.InvoiceRepository;

namespace DataAccess.CQRS.Queries.InvoiceQueries
{
    public class GetInvoiceByInvoiceNumberQuery : QueryBase<Invoice>
    {
        public string InvoiceNumber { get; set; }
        
        private readonly IInvoiceRepository _invoiceRepository;

        public GetInvoiceByInvoiceNumberQuery(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public override async Task<Invoice> Execute()
        {
            return await _invoiceRepository.GetInvoiceByInvoiceNumber(InvoiceNumber);
        }
    }
}