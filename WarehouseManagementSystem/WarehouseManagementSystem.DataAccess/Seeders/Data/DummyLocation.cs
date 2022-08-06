using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Enums;

namespace DataAccess.Seeders.Data
{
    public static class DummyLocation
    {
        public static List<Location> GetDummyLocations()
        {
            return new List<Location>()
            {
                new Location()
                {
                    LocationType = LocationType.NORMAL,
                    CurrentAmount = 0,
                    Name = "A-02-05",
                    MaxAmount = 100
                },
                new Location()
                {
                    LocationType = LocationType.FRIDGE,
                    CurrentAmount = 50,
                    Name = "Z-02-05",
                    MaxAmount = 100
                },
                new Location()
                {
                    LocationType = LocationType.SHORT_DATE,
                    CurrentAmount = 2,
                    Name = "X-01-03",
                    MaxAmount = 25
                }
            };
        }

        public static void SetDummyLocations(WMSDatabaseContext context)
        {
            var location1 = context.Locations.Skip(1).First();
            var location2 = context.Locations.Skip(2).First();

            var product1 = context.Products.First();
            var product2 = context.Products.Skip(1).First();

            location1.ProductId = product1.Id;
            location2.ProductId = product2.Id;
        }
    }
}