using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void SetOrderRows(WMSDatabaseContext context)
        {
            var product1 = context.Products.First();
            var product2 = context.Products.Skip(1).First();
            var product3 = context.Products.Skip(2).First();
            var product4 = context.Products.Skip(3).First();
            var product5 = context.Products.Skip(4).First();

            var order1 = context.Orders.Skip(2).First();
            var order2 = context.Orders.Skip(3).First();
            var order3 = context.Orders.Skip(4).First();

            var orderRow1 = context.OrderRows.First();
            var orderRow2 = context.OrderRows.Skip(1).First();
            var orderRow3 = context.OrderRows.Skip(2).First();
            var orderRow4 = context.OrderRows.Skip(3).First();
            var orderRow5 = context.OrderRows.Skip(4).First();
            var orderRow6 = context.OrderRows.Skip(5).First();
            var orderRow7 = context.OrderRows.Skip(6).First();

            orderRow1.ProductId = product1.Id;
            orderRow1.OrderId = order1.Id;

            orderRow2.ProductId = product2.Id;
            orderRow2.OrderId = order1.Id;

            orderRow3.ProductId = product2.Id;
            orderRow3.OrderId = order2.Id;
            
            orderRow4.ProductId = product3.Id;
            orderRow4.OrderId = order2.Id;
            
            orderRow5.ProductId = product4.Id;
            orderRow5.OrderId = order3.Id;
            
            orderRow6.ProductId = product5.Id;
            orderRow6.OrderId = order3.Id;
            
            orderRow7.ProductId = product1.Id;
            orderRow7.OrderId = order3.Id;
        }
    }
}