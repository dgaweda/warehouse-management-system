using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Enums;

namespace WMS.DataAccess.Test.Extensions.PalletExtensionTests.TestData
{
    public class SetStatusTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Pallet()
                {
                    Order = new Order(),
                },
                PalletStatus.OPEN
            };
            
            yield return new object[]
            {
                new Pallet()
                {
                    Order = new Order(),
                    OrderId = new Guid(),
                },
                PalletStatus.OPEN
            };
            
            yield return new object[]
            {
                new Pallet()
                {
                    Order = new Order(),
                    OrderId = new Guid(),
                    UserId = new Guid(),
                },
                PalletStatus.OPEN
            };
            
            yield return new object[]
            {
                new Pallet()
                {
                    DepartureId = new Guid(),
                    Departure = new Departure()
                    {
                        State = StateType.CLOSED
                    }
                },
                PalletStatus.SENT
            };
            
            yield return new object[]
            {
                new Pallet()
                {
                    DepartureId = new Guid(),
                    Departure = new Departure()
                    {
                        State = StateType.OPEN
                    }
                },
                PalletStatus.OPEN
            };
            
            yield return new object[]
            {
                new Pallet()
                {
                    OrderId = new Guid(),
                    UserId = new Guid(), 
                    Order = new Order()
                    {
                        OrderState = OrderState.READY_FOR_DEPARTURE
                    }
                },
                PalletStatus.READY_FOR_DEPARTURE
            };
            
            yield return new object[]
            {
                new Pallet()
                {
                    UserId = new Guid(), 
                    Order = new Order()
                    {
                        OrderState = OrderState.READY_FOR_DEPARTURE
                    }
                },
                PalletStatus.OPEN
            };
            
            yield return new object[]
            {
                new Pallet()
                {
                    OrderId = new Guid(),
                    UserId = new Guid(), 
                    Order = new Order()
                    {
                        OrderState = OrderState.IN_PROGRESS
                    }
                },
                PalletStatus.DURING_ORDER_PICKING
            };
            
            yield return new object[]
            {
                new Pallet()
                {
                    InvoiceId = new Guid(),
                },
                PalletStatus.READY_TO_BE_UNFOLDED
            };
            
            yield return new object[]
            {
                new Pallet()
                {
                    OrderId = new Guid(),
                    UserId = new Guid(),
                    Order = new Order()
                    {
                        OrderState = OrderState.IN_PROGRESS
                    },
                    InvoiceId = new Guid(),
                },
                PalletStatus.DURING_ORDER_PICKING
            };
        }

            IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}