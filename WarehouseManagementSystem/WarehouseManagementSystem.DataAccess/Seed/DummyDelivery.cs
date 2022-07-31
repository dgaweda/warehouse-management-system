using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DataAccess.Entities;

namespace DataAccess.Seed
{
    public static class DummyDeliveries
    {
        public static IEnumerable<Delivery> GetDummyDeliveries()
        {
            var arrivalNow = DateTime.Now;
            var arrivalSamepleData = new DateTime(2022, 9, 15);
            var arrivalSamepleData2 = new DateTime(2022, 5, 3);
            var arrivalSamepleData3 = new DateTime(2021, 3, 1);
            
            
            return new []
            {
               new Delivery()
               {
                   Arrival = arrivalNow,
                   Id = new Guid("f93239da-4d20-4cb9-a8b7-df9002e4a042"),
                   Name = $"1/{arrivalNow.Date.Day}/{arrivalNow.Date.Month}/{arrivalNow.Date.Year}"
               },
               new Delivery()
               {
                   Arrival = arrivalSamepleData,
                   Id = new Guid("7702b744-7426-4cac-8eb6-d096c8d6cdeb"),
                   Name = $"1/{arrivalSamepleData.Date.Day}/{arrivalSamepleData.Date.Month}/{arrivalSamepleData.Date.Year}"
               },
               new Delivery()
               {
                   Arrival = arrivalSamepleData2,
                   Id = new Guid("6b47ca86-1a8f-43b1-a665-59d374211290"),
                   Name = $"1/{arrivalSamepleData2.Date.Day}/{arrivalSamepleData2.Date.Month}/{arrivalSamepleData2.Date.Year}"
               },
               new Delivery()
               {
                   Arrival = arrivalSamepleData3,
                   Id = new Guid("bcc7a4dd-80c6-42ec-a5aa-b68e235f7bb6"),
                   Name = $"1/{arrivalSamepleData3.Date.Day}/{arrivalSamepleData3.Date.Month}/{arrivalSamepleData3.Date.Year}"
               }
            };
        }
    }
}