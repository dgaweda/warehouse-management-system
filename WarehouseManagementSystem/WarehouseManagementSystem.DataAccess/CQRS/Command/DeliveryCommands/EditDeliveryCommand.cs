using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.DeliveryRepository;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class EditDeliveryCommand : CommandBase<Delivery, Delivery, IDeliveryRepository>
    {
        public override async Task<Delivery> Execute(IDeliveryRepository deliveryRepository)
        {
            return await deliveryRepository.UpdateAsync(Parameter);
        }
    }
}
