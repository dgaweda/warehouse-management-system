using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.DeliveryRepository;
using Microsoft.EntityFrameworkCore;

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
