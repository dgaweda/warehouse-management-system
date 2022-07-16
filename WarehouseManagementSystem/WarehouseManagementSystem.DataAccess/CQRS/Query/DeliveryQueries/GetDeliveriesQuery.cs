using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.DeliveryRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Query.Queries.DeliveryQueries
{
    public class GetDeliveriesQuery : QueryBase<List<Delivery>>
    {
        public string Name { get; set; }

        private readonly IDeliveryRepository _deliveryRepository;

        public GetDeliveriesQuery(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public override async Task<List<Delivery>> Execute()
        {
            return await _deliveryRepository.GetAll()
                .FilterByName(Name)
                .ToListAsync();
        }
    }
}
