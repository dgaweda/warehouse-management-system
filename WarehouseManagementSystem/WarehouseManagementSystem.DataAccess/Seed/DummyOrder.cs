using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Seed
{
    public static class DummyOrder
    {
        public static IEnumerable<Order> GetDummyOrders()
        {
            return new[]
            {
                new Order()
                {
                    OrderState = OrderState.RECEIVED,
                    Barcode = "100",
                    
                }
            };
        }
    }
}