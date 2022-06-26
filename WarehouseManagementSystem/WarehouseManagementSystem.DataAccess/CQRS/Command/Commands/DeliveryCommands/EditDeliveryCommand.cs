using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class EditDeliveryCommand : CommandBase<Delivery, Delivery>
    {
        public override async Task<Delivery> Execute(IRepository<Delivery> deliveryRepository)
        {
            return await deliveryRepository.UpdateAsync(Parameter);
        }
    }
}
