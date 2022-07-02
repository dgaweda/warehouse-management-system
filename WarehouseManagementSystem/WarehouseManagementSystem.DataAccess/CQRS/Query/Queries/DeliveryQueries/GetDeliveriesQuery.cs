using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.CQRS.Queries;
using DataAccess.Entities;
using DataAccess.Exceptions;
using DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Query.Queries.DeliveryQueries
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
