using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Extensions;
using DataAccess.Repository;
using DataAccess.Repository.DeliveryRepository;

namespace DataAccess.CQRS.Commands.DeliveryCommands
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
