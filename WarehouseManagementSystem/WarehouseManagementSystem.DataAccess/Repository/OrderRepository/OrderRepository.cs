using System;
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

        public override async Task<Order> GetByIdAsync(Guid id)
        {
            return await GetAll()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override IQueryable<Order> GetAll()
        {
            return Entity
                .Include(x => x.OrderRows)
                .AsQueryable();
        }
    }
}