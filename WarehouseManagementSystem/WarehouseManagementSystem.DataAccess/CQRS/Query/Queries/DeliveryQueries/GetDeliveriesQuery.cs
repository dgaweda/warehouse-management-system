using DataAccess.CQRS.Helpers;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.DeliveryQueries
{
    public class GetDeliveriesQuery : QueryBase<List<Delivery>>
    {
        public string Name { get; set; }

        public override async Task<List<Delivery>> Execute(WMSDatabaseContext context)
        {
            var deliveries = await context.Deliveries.ToListAsync();

            return deliveries.FilterByName(Name);
        }
    }
}
