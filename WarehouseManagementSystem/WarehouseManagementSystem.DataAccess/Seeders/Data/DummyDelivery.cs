using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seeders.Data
{
    public static class DummyDeliveries
    {
        public static List<Delivery> GetDummyDeliveries()
        {
            var arrivalSampleData = new DateTime(2022, 8, 7);
            var arrivalSampleData2 = new DateTime(2022, 9, 15);
            var arrivalSampleData3 = new DateTime(2022, 5, 3);
            var arrivalSampleData4 = new DateTime(2021, 3, 1);
            var arrivalSampleData5 = new DateTime(2021, 3, 1);
            
            
            return new List<Delivery>()
            {
               new Delivery()
               {
                   Id = new Guid("2AD32177-D693-4E24-BB89-6DD2F7DABF28"),
                   Arrival = arrivalSampleData,
                   Name = $"1/{arrivalSampleData.Date.Day}/{arrivalSampleData.Date.Month}/{arrivalSampleData.Date.Year}"
               },
               new Delivery()
               {
                   Id = new Guid("A33F8D42-5618-40F8-B4AB-14AF7440740C"),
                   Arrival = arrivalSampleData2,
                   Name = $"1/{arrivalSampleData2.Date.Day}/{arrivalSampleData2.Date.Month}/{arrivalSampleData2.Date.Year}"
               },
               new Delivery()
               {
                   Id = new Guid("0D2E9948-0C39-456B-84F8-46D6FB0203CC"),
                   Arrival = arrivalSampleData3,
                   Name = $"1/{arrivalSampleData3.Date.Day}/{arrivalSampleData3.Date.Month}/{arrivalSampleData3.Date.Year}"
               },
               new Delivery()
               {
                   Id = new Guid("782FC047-E679-43BB-BF49-45C76E6543A9"),
                   Arrival = arrivalSampleData4,
                   Name = $"1/{arrivalSampleData4.Date.Day}/{arrivalSampleData4.Date.Month}/{arrivalSampleData4.Date.Year}"
               },
               new Delivery()
               {
                   Id = new Guid("BE7BEC06-4E1B-48D6-9534-1C68E9EF2A6C"),
                   Arrival = arrivalSampleData5,
                   Name = $"1/{arrivalSampleData5.Date.Day}/{arrivalSampleData5.Date.Month}/{arrivalSampleData5.Date.Year}"
               }
            };
        }
    }
}