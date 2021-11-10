using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class AddDeliveryCommand : CommandBase<Delivery, Delivery>
    {
        public override async Task<Delivery> Execute(WMSDatabaseContext context)
        {
            var deliveries = await context.Deliveries.ToListAsync();
            new SetDeliveryName(deliveries, Parameter);

            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }

    }
}
