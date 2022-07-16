using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Repository.OrderLineRepository
{
    public class OrderLineRepository : Repository<OrderLine>, IOrderLineRepository
    {
        public OrderLineRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}