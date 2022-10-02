using System;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Enums;

namespace DataAccess.Seeders.Data
{
    public static class DummyOrder
    {
        public static List<Order> GetDummyOrders()
        {
            return new List<Order>()
            {
                new Order()
                {
                    Id = new Guid("C55CFF17-FC8F-4433-8A17-5F548C7B8A58"),
                    OrderState = OrderState.RECEIVED,
                    Barcode = "100",
                },
                new Order()
                {
                    Id = new Guid("5A57665F-AE56-4B8B-8411-207854A00457"),
                    OrderState = OrderState.CANCELED,
                    Barcode = "101",
                },
                new Order()
                {
                    Id = new Guid("F0F63ECC-82D6-4882-981F-61805F98226F"),
                    OrderState = OrderState.SENT,
                    PickingStart = new DateTime(2022, 06, 13, 10, 15, 20),
                    PickingEnd = new DateTime(2022, 06, 13, 11, 15, 20),
                    Barcode = "102",
                },
                new Order()
                {
                    Id = new Guid("B44B313F-92D2-49CE-8A1D-F581AFF548F0"),
                    OrderState = OrderState.IN_PROGRESS,
                    PickingStart = new DateTime(2022, 06, 15, 12, 15, 20),
                    Barcode = "103",
                },
                new Order()
                {
                    Id = new Guid("C880A591-CF2E-40A3-8676-3659857A4738"),
                    OrderState = OrderState.READY_FOR_DEPARTURE,
                    PickingStart = new DateTime(2022, 06, 15, 10, 15, 20),
                    PickingEnd = new DateTime(2022, 06, 15, 11, 15, 20),
                    Barcode = "104",
                }
            };
        }
    }
}