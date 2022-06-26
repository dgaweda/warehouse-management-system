using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Extensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.OrderQueries
{
    public class GetOrdersQuery: QueryBase<List<Order>>
    {
        public int? Id { get; set; }

        public override async Task<List<Order>> Execute(WMSDatabaseContext context)
        {
            var orders = await context.Orders
                .Include(x => x.OrderLines)
                .ToListAsync();
            return orders.FilterById(Id);
        }
    }
}