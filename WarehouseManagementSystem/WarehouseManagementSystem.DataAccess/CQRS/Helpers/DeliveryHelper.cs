using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.CQRS.Helpers
{
    public static class DeliveryHelper
    {
        public static int SetDeliveryNumber(this Delivery Parameter, List<Delivery> deliveries)
        {
            var deliveriesInSameDay = 1;
            deliveries.ForEach(property =>
            {
                if (property.Arrival.Date == Parameter.Arrival.Date)
                    deliveriesInSameDay++;
            });

            return deliveriesInSameDay;
        }

        public static Delivery SetDeliveryName(this int deliveryNumber, Delivery delivery)
        {
            delivery.Name = $"DOSTAWA/{deliveryNumber}/DATA/{delivery.Arrival.Date.Day}/{delivery.Arrival.Date.Month}/{delivery.Arrival.Date.Year}";
            return delivery;
        }
    }
}
