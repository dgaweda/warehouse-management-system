using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seeders.Data
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
                    Price = Convert.ToDecimal(10.50),
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