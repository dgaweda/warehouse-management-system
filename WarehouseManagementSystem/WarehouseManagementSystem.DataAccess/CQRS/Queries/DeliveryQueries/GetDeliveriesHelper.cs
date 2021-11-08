using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.DeliveryQueries
{
    public class GetDeliveriesHelper : IGetEntityHelper<Delivery>
    {
        public string Name { get; set; }

        public async Task<List<Delivery>> GetFilteredData(WMSDatabaseContext context)
        {
            var deliveries = await context.Deliveries.ToListAsync();

            if (PropertiesAreEmpty())
                return deliveries;
            else
                return SearchByName(deliveries);
        }

        public bool PropertiesAreEmpty() => string.IsNullOrEmpty(Name);
        private List<Delivery> SearchByName(List<Delivery> deliveries) => deliveries.Where(delivery => delivery.Name.Contains(Name.ToUpper())).ToList();
    }
}
