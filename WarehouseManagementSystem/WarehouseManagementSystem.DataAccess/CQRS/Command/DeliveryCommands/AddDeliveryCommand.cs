using System;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.DeliveryRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Command.DeliveryCommands
{
    public class AddDeliveryCommand : CommandBase<Delivery, Delivery, IDeliveryRepository>
    {
        public override async Task<Delivery> Execute(IDeliveryRepository deliveryRepository)
        {
            var deliveries = await deliveryRepository.Entity.ToListAsync();
            Parameter
                .SetDeliveryNumber(deliveries)
                .SetDeliveryName(Parameter);
            
            return await deliveryRepository.AddAsync(Parameter);
        }
    }
}
