using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.InvoiceRepository;

namespace DataAccess.CQRS.Query.InvoiceQueries
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