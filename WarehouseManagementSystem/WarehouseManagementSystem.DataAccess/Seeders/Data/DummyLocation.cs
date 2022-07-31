using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Seed
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
                    MaxAmount = 100,
                    ProductId = Guid.Parse("d77b3a62-c4d4-4b12-a703-9bdd88b027ba")
                },
                new Location()
                {
                    LocationType = LocationType.SHORT_DATE,
                    CurrentAmount = 2,
                    Name = "X-01-03",
                    MaxAmount = 25,
                    ProductId = Guid.Parse("2e9d5cea-618f-4da1-9247-23e4ad731940")
                }
            };
        }
    }
}