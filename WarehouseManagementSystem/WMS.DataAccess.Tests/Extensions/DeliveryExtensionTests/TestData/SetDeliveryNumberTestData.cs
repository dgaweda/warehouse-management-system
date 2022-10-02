using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Seeders.Data;

namespace WMS.DataAccess.Test.Extensions
{
    public class SetDeliveryNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                new Delivery()
                {
                    Id = new Guid("A33F8D42-5618-40F8-B4AB-14AF7440740C"),
                    Arrival = new DateTime(2022, 9, 15, 0, 0, 0),
                    Name = "1/15/9/2022"
                },
                2
            };
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                new Delivery()
                {
                    Id = new Guid("782FC047-E679-43BB-BF49-45C76E6543A9"),
                    Arrival = new DateTime(2021, 3, 1, 0, 0, 0),
                    Name = "1/1/3/2021"
                },
                3
            };
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                new Delivery()
                {
                    Id = new Guid("BE7BEC06-4E1B-48D6-9534-1C68E9EF2A6C"),
                    Arrival = new DateTime(2021, 3, 1, 0, 0, 0),
                    Name = "1/1/3/2021"
                },
                3
            };
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                new Delivery()
                {
                    Id = Guid.NewGuid(),
                    Arrival = new DateTime(2050, 3, 1, 0, 0, 0),
                    Name = "1/1/3/2050"
                },
                1
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}