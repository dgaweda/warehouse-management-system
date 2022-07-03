using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.DeliveryRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class RemoveDeliveryCommand : CommandBase<Delivery, Delivery, IDeliveryRepository>
    {
        public override async Task<Delivery> Execute(IDeliveryRepository deliveryRepository)
        {
            var delivery = await deliveryRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await deliveryRepository.DeleteAsync(Parameter.Id);
            return delivery;
        }
    }
}
