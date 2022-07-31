using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.InvoiceRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Query.InvoiceQueries
{
    public class GetInvoicesQuery : QueryBase<List<Invoice>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public GetInvoicesQuery(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        
        public override async Task<List<Invoice>> Execute()
        {
            return await _invoiceRepository.GetAll().ToListAsync();
        }
    }
}
