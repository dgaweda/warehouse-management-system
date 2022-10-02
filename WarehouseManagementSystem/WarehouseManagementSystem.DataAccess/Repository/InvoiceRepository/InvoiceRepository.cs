using System;
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

        public override async Task<Invoice> GetByIdAsync(Guid id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Invoice> GetInvoiceByInvoiceNumber(string invoiceNumber)
        {
            return await GetAll()
                .FirstOrDefaultAsync(x => x.InvoiceNumber == invoiceNumber);
        }

        public override IQueryable<Invoice> GetAll()
        {
            return Entity
                .Include(x => x.Delivery)
                .AsQueryable();
        }
    }
}