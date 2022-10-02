using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Seeders.Data;

namespace WMS.DataAccess.Test.Extensions
{
    public class DeliveryExtensionTestsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                new List<Delivery>()
                {
                    new Delivery()
                    {
                        Id = new Guid("A33F8D42-5618-40F8-B4AB-14AF7440740C"),
                        Arrival = new DateTime(2022, 9, 15, 0, 0, 0),
                        Name = "1/15/9/2022"
                    }
                },
                "1/15/9/2022"
            };
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                new List<Delivery>()
                {
                    new Delivery()
                    {
                        Id = new Guid("A33F8D42-5618-40F8-B4AB-14AF7440740C"),
                        Arrival = new DateTime(2022, 9, 15, 0, 0, 0),
                        Name = "1/15/9/2022"
                    }
                },
                "1/15"
            };
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                new List<Delivery>()
                {
                    new Delivery()
                    {
                        Id = new Guid("782FC047-E679-43BB-BF49-45C76E6543A9"),
                        Arrival = new DateTime(2021, 3, 1, 0, 0, 0),
                        Name = "1/1/3/2021"
                    },
                    new Delivery()
                    {
                        Id = new Guid("BE7BEC06-4E1B-48D6-9534-1C68E9EF2A6C"),
                        Arrival = new DateTime(2021, 3, 1, 0, 0, 0),
                        Name = "1/1/3/2021"
                    }
                },
                "1/1/3"
            };
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                new List<Delivery>()
                {
                    new Delivery()
                    {
                        Id = new Guid("782FC047-E679-43BB-BF49-45C76E6543A9"),
                        Arrival = new DateTime(2021, 3, 1, 0, 0, 0),
                        Name = "1/1/3/2021"
                    },
                    new Delivery()
                    {
                        Id = new Guid("BE7BEC06-4E1B-48D6-9534-1C68E9EF2A6C"),
                        Arrival = new DateTime(2021, 3, 1, 0, 0, 0),
                        Name = "1/1/3/2021"
                    }
                },
                "3/2021"
            };
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                new List<Delivery>()
                {
                    new Delivery()
                    {
                        Id = new Guid("0D2E9948-0C39-456B-84F8-46D6FB0203CC"),
                        Arrival = new DateTime(2022, 5, 3, 0, 0, 0),
                        Name = "1/3/5/2022"
                    },
                    new Delivery()
                    {
                        Id = new Guid("782FC047-E679-43BB-BF49-45C76E6543A9"),
                        Arrival = new DateTime(2021, 3, 1, 0, 0, 0),
                        Name = "1/1/3/2021"
                    },
                    new Delivery()
                    {
                        Id = new Guid("BE7BEC06-4E1B-48D6-9534-1C68E9EF2A6C"),
                        Arrival = new DateTime(2021, 3, 1, 0, 0, 0),
                        Name = "1/1/3/2021"
                    }
                },
                "1/3"
            };
            yield return new object[]
            {
                DummyDeliveries.GetDummyDeliveries(),
                DummyDeliveries.GetDummyDeliveries(),
                ""
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}