using System;
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
            return await GetQueryableEntity() 
                .ToListAsync();
        }

        public override async Task<Order> GetByIdAsync(Guid id)
        {
            return await GetQueryableEntity()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override IQueryable<Order> GetQueryableEntity()
        {
            return Entity
                .Include(x => x.OrderLines)
                .AsQueryable();
        }
    }
}