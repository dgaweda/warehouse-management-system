using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class RemoveDeliveryCommand : CommandBase<Delivery, Delivery>
    {
        public override async Task<Delivery> Execute(IRepository<Delivery> deliveryRepository)
        {
            var delivery = await deliveryRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await deliveryRepository.DeleteAsync(Parameter.Id);
            return delivery;
        }
    }
}
