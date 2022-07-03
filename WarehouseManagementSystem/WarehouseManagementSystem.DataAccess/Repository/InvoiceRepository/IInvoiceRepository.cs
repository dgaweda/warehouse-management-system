using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository.InvoiceRepository
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<Invoice> GetInvoiceByInvoiceNumber(string invoiceNumber);
    }
}