using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.DeliveryQueries
{
    public class GetDeliveriesQuery : QueryBase<List<Delivery>>
    {
        private readonly IGetEntityHelper<Delivery> _delivery;
        public GetDeliveriesQuery(IGetEntityHelper<Delivery> helper)
        {
            _delivery = helper;
        }
        public override async Task<List<Delivery>> Execute(WMSDatabaseContext context) => await _delivery.GetFilteredData(context);
    }
}
