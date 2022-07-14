using System;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.DeliveryRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Command.DeliveryCommands
{
    public class AddDeliveryCommand : CommandBase<Delivery, IDeliveryRepository>
    {
        public override async Task Execute(IDeliveryRepository deliveryRepository)
        {
            var deliveries = await deliveryRepository.Entity.ToListAsync();
            Parameter
                .SetDeliveryNumber(deliveries)
                .SetDeliveryName(Parameter);
            
            await deliveryRepository.AddAsync(Parameter);
        }
    }
}
