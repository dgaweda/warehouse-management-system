using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seed
{
    public static class DummyOrderRow
    {
        public static List<OrderRow> GetDummyOrderRows()
        {
            return new List<OrderRow>()
            {
                new OrderRow()
                {
                    Amount = 5,
                    Id = Guid.Parse("ad4bb54a-f304-49cd-bf6f-bcefb231045c"),
                    Price = Convert.ToDecimal(10.50),
                    OrderId = Guid.Parse("186630f0-aadc-4ed8-89be-3e73b61328a5"),
                    ProductId = Guid.Parse("76d175b7-bfa3-4e42-9cae-aa40534eeed2")
                },
                new OrderRow()
                {
                    Amount = 10,
                    Price = Convert.ToDecimal(15.05),
                },
                new OrderRow()
                {
                    Amount = 90,
                    Price = Convert.ToDecimal(15.05),
                },
                new OrderRow()
                {
                    Amount = 25,
                    Price = Convert.ToDecimal(20.05),
                },
                new OrderRow()
                {
                    Amount = 50,
                    Price = Convert.ToDecimal(12.05),
                },
                new OrderRow()
                {
                    Amount = 15,
                    Price = Convert.ToDecimal(11.05)
                },
                new OrderRow()
                {
                    Amount = 15,
                    Price = Convert.ToDecimal(25.05)
                },
            };
        }
    }
}