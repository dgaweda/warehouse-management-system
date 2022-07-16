using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Repository.InvoiceRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.InvoiceQueries
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
