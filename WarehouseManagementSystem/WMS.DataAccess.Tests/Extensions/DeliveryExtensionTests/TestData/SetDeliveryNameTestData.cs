using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;

namespace WMS.DataAccess.Test.Extensions
{
    public class SetDeliveryNameTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                1,
                new Delivery()
                {
                    Arrival = new DateTime(2000, 1, 1),
                },
                "1/1/1/2000"
            };
            yield return new object[]
            {
                1,
                new Delivery()
                {
                    Arrival = new DateTime(2010, 9, 17),
                },
                "1/17/9/2010"
            };
            yield return new object[]
            {
                2,
                new Delivery()
                {
                    Arrival = new DateTime(2019, 7, 15),
                },
                "2/15/7/2019"
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}