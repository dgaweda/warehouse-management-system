using System;
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

        public override async Task<Invoice> GetByIdAsync(Guid id)
        {
            return await GetQueryableEntity().FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<Invoice>> GetAllAsync()
        {
            return await GetQueryableEntity().ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByInvoiceNumber(string invoiceNumber)
        {
            return await GetQueryableEntity()
                .FirstOrDefaultAsync(x => x.InvoiceNumber == invoiceNumber);
        }

        public override IQueryable<Invoice> GetQueryableEntity()
        {
            return Entity
                .Include(x => x.Delivery)
                .AsQueryable();
        }
    }
}