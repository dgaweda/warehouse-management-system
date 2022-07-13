using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.DeliveryRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class RemoveDeliveryCommand : CommandBase<Delivery, Unit, IDeliveryRepository>
    {
        public override async Task<Unit> Execute(IDeliveryRepository deliveryRepository)
        {
            return await deliveryRepository.DeleteAsync(Parameter.Id);
        }
    }
}
