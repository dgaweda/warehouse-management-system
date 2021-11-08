using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class RemoveDeliveryCommand : CommandBase<Delivery, Delivery>
    {
        public override async Task<Delivery> Execute(WMSDatabaseContext context)
        {
            var delivery = await context.Deliveries.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            context.Remove(delivery);
            await context.SaveChangesAsync();
            return delivery;
        }
    }
}
