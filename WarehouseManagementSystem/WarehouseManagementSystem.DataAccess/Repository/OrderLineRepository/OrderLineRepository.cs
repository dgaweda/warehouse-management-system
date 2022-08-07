using DataAccess.Entities;

namespace DataAccess.Repository.OrderLineRepository
{
    public class OrderLineRepository : Repository<OrderRow>, IOrderLineRepository
    {
        public OrderLineRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}