using System;
using System.Reflection.Metadata;
using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.DeliveryRepository;
using MediatR;

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
