using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Seed
{
    public static class DummyOrder
    {
        public static List<Order> GetDummyOrders()
        {
            return new List<Order>()
            {
                new Order()
                {
                    OrderState = OrderState.RECEIVED,
                    Barcode = "100",
                },
                new Order()
                {
                    OrderState = OrderState.CANCELED,
                    Barcode = "101",
                },
                new Order()
                {
                    OrderState = OrderState.SENT,
                    PickingStart = new DateTime(2022, 06, 13, 10, 15, 20),
                    PickingEnd = new DateTime(2022, 06, 13, 11, 15, 20),
                    Barcode = "102",
                },
                new Order()
                {
                    OrderState = OrderState.IN_PROGRESS,
                    PickingStart = new DateTime(2022, 06, 15, 12, 15, 20),
                    Barcode = "103",
                },
                new Order()
                {
                    OrderState = OrderState.READY_FOR_DEPARTURE,
                    PickingStart = new DateTime(2022, 06, 15, 10, 15, 20),
                    PickingEnd = new DateTime(2022, 06, 15, 11, 15, 20),
                    Barcode = "104",
                }
            };
        }
    }
}