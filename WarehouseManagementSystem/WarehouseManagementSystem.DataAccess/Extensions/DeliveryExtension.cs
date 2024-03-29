﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Exceptions;

namespace DataAccess.Extensions
{
    public static class DeliveryExtension
    {
        public static int SetDeliveryNumber(this Delivery parameter, List<Delivery> deliveries)
        {
            var deliveriesInSameDay = 1;
            deliveries.ForEach(property =>
            {
                if (property.Arrival.Date == parameter.Arrival.Date)
                    deliveriesInSameDay++;
            });

            return deliveriesInSameDay;
        }

        public static Delivery SetDeliveryName(this int deliveryNumber, Delivery delivery)
        {
            if (delivery.Arrival == DateTime.MinValue)
                throw new InvalidDateTimeException();
            
            delivery.Name = $"{deliveryNumber}/{delivery.Arrival.Date.Day}/{delivery.Arrival.Date.Month}/{delivery.Arrival.Date.Year}";
            return delivery;
        }

        public static IQueryable<Delivery> FilterByName(this IQueryable<Delivery> deliveries, string name)
        {
            if (string.IsNullOrEmpty(name))
                return deliveries;

            return deliveries.Where(delivery => delivery.Name.Contains(name.ToUpper()));
        }
    }
}
