﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataAccess.CQRS.Extensions;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class AddDeliveryCommand : CommandBase<Delivery, Delivery>
    {
        public override async Task<Delivery> Execute(IRepository<Delivery> deliveryRepository)
        {
            var deliveries = await deliveryRepository.Entity.ToListAsync();
            Parameter
                .SetDeliveryNumber(deliveries)
                .SetDeliveryName(Parameter);

            await deliveryRepository.Add(Parameter);
            return Parameter;
        }
    }
}
