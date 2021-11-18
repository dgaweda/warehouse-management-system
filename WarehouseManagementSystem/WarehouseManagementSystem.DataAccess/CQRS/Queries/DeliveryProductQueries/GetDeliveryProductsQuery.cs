using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.DeliveryProductQueries
{
    public class GetDeliveryProductsQuery : QueryBase<List<DeliveryProduct>>
    {
        private readonly IGetEntityHelper<DeliveryProduct> _deliveryProduct;
        public GetDeliveryProductsQuery(IGetEntityHelper<DeliveryProduct> deliveryProduct)
        {
            _deliveryProduct = deliveryProduct;
        }

        public override async Task<List<DeliveryProduct>> Execute(WMSDatabaseContext context) => await _deliveryProduct.GetFilteredData(context);
    }
}
