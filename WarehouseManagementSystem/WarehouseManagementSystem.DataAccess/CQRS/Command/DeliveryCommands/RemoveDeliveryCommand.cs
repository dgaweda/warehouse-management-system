using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.DeliveryRepository;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class RemoveDeliveryCommand : CommandBase<Delivery, IDeliveryRepository>
    {
        public override async Task Execute(IDeliveryRepository deliveryRepository)
        {
            await deliveryRepository.DeleteAsync(Parameter.Id);
        }
    }
}
