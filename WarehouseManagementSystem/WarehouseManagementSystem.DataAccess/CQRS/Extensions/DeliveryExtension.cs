using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.CQRS.Extensions
{
    public static class DeliveryExtension
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

        public static List<Delivery> FilterByName(this List<Delivery> deliveries, string Name)
        {
            if (string.IsNullOrEmpty(Name))
                return deliveries;

            return deliveries.Where(delivery => delivery.Name.Contains(Name.ToUpper())).ToList();
        }
    }
}
