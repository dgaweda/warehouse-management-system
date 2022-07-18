using System;
using System.Collections.Generic;
using DataAccess.Entities;
using Xunit;

namespace WMSTest.Extensions
{
    public class DeliveryExtensionTest
    {
        private readonly Delivery _delivery;
        private readonly List<Delivery> _deliveries;

        public DeliveryExtensionTest()
        {
            _deliveries = new List<Delivery>()
            {

            };

            _delivery = new Delivery()
            {
                Id = new Guid(),
                Arrival = DateTime.Now,
                Name = "Delivery_Test"
            };
        }
        [Theory]
        [ClassData(_delivery)]
        public int SetDeliveryNumber_ForTwoDeliveriesSameDate_ReturnsTwoAsDeliveryNumberInSameDay(Delivery delivery, List<Delivery> deliveries)
        {

        }
    }
}