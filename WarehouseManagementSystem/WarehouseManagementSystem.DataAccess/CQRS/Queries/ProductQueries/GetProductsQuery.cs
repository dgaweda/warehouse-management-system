using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.DeliveryProductQueries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        private readonly IGetEntityHelper<Product> _deliveryProduct;
        public GetProductsQuery(IGetEntityHelper<Product> deliveryProduct)
        {
            _deliveryProduct = deliveryProduct;
        }

        public override async Task<List<Product>> Execute(WMSDatabaseContext context) => await _deliveryProduct.GetFilteredData(context);
    }
}
