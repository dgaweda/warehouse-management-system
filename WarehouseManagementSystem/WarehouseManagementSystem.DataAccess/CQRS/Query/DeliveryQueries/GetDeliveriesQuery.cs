using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.DeliveryRepository;

namespace DataAccess.CQRS.Query.Queries.DeliveryQueries
{
    public class GetDeliveriesQuery : QueryBase<List<Delivery>, IDeliveryRepository>
    {
        public string Name { get; set; }

        public override async Task<List<Delivery>> Execute(IDeliveryRepository deliveryRepository)
        {
            var deliveries = await deliveryRepository.GetAllAsync();
            return deliveries.FilterByName(Name);
        }
    }
}
