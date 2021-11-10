using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class EditDeliveryCommand : CommandBase<Delivery, Delivery>
    {
        public override async Task<Delivery> Execute(WMSDatabaseContext context)
        {
            if (Parameter == null)
                throw new ArgumentNullException("Parameter is Null");

            var deliveries = await context.Deliveries.ToListAsync();
            var deliveryToDetach = deliveries.FirstOrDefault(x => x.Id == Parameter.Id);
            new SetDeliveryName(deliveries, Parameter);

            context.Entry(deliveryToDetach).State = EntityState.Detached;
            context.Entry(Parameter).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
