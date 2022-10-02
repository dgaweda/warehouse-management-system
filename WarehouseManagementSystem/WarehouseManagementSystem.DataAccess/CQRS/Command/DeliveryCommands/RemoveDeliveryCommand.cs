using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.DeliveryRepository;

namespace DataAccess.CQRS.Command.DeliveryCommands
{
    public class RemoveDeliveryCommand : CommandBase<Delivery, IDeliveryRepository>
    {
        public override async Task Execute(IDeliveryRepository deliveryRepository)
        {
            await deliveryRepository.DeleteAsync(Parameter.Id);
        }
    }
}
