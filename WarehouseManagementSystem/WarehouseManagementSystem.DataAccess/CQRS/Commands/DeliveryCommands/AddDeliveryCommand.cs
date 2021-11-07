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
            SetDeliveryName(deliveries);
            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }

        private void SetDeliveryName(List<Delivery> deliveries)
        {
            var deliveryNumber = CountDateRepetitionInDB(deliveries);
            Parameter.Name = $"DELIVERY/{deliveryNumber}/DATE/{Parameter.Arrival.Date.Day}/{Parameter.Arrival.Date.Month}/{Parameter.Arrival.Date.Year}";
        }

        private int CountDateRepetitionInDB(List<Delivery> deliveries)
        {
            var deliveriesInSameDay = 1;
            deliveries.ForEach(property =>
            {
                if (property.Arrival.Date == Parameter.Arrival.Date)
                    deliveriesInSameDay++;
            });

            return deliveriesInSameDay;
        }
    }
}
