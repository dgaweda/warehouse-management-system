using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.InvoiceRepository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Invoice> GetByIdAsync(int id)
        {
            return await GetInvoices().FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<Invoice>> GetAllAsync()
        {
            return await GetInvoices().ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByInvoiceNumber(string invoiceNumber)
        {
            return await GetInvoices()
                .FirstOrDefaultAsync(x => x.InvoiceNumber == invoiceNumber);
        }

        private IQueryable<Invoice> GetInvoices()
        {
            return DbContext.Invoices
                .Include(x => x.Delivery)
                .AsQueryable();
        }
    }
}