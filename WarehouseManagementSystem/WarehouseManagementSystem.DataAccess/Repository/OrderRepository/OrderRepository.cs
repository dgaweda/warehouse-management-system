using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.OrderRepository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Order>> GetAllAsync()
        {
            return await GetOrders() 
                .ToListAsync();
        }

        public override async Task<Order> GetByIdAsync(int id)
        {
            return await GetOrders()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        private IQueryable<Order> GetOrders()
        {
            return DbContext.Orders
                .Include(x => x.OrderLines)
                .AsQueryable();
        }
    }
}