using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DataAccess.Entities;

namespace DataAccess.Seed
{
    public static class DummyDeliveries
    {
        public static List<Delivery> GetDummyDeliveries()
        {
            var arrivalNow = DateTime.Now;
            var arrivalSamepleData = new DateTime(2022, 9, 15);
            var arrivalSamepleData2 = new DateTime(2022, 5, 3);
            var arrivalSamepleData3 = new DateTime(2021, 3, 1);
            
            
            return new List<Delivery>()
            {
               new Delivery()
               {
                   Arrival = arrivalNow,
                   Name = $"1/{arrivalNow.Date.Day}/{arrivalNow.Date.Month}/{arrivalNow.Date.Year}"
               },
               new Delivery()
               {
                   Arrival = arrivalSamepleData,
                   Name = $"1/{arrivalSamepleData.Date.Day}/{arrivalSamepleData.Date.Month}/{arrivalSamepleData.Date.Year}"
               },
               new Delivery()
               {
                   Arrival = arrivalSamepleData2,
                   Name = $"1/{arrivalSamepleData2.Date.Day}/{arrivalSamepleData2.Date.Month}/{arrivalSamepleData2.Date.Year}"
               },
               new Delivery()
               {
                   Arrival = arrivalSamepleData3,
                   Name = $"1/{arrivalSamepleData3.Date.Day}/{arrivalSamepleData3.Date.Month}/{arrivalSamepleData3.Date.Year}"
               }
            };
        }
    }
}