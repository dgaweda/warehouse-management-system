using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Seed
{
    public static class DummyLocation
    {
        public static IEnumerable<Location> GetDummyLocations()
        {
            return new[]
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
                    ProductId = new Guid("")
                },
                new Location()
                {
                    LocationType = LocationType.SHORT_DATE,
                    CurrentAmount = 2,
                    Name = "X-01-03",
                    MaxAmount = 25,
                    ProductId = new Guid("")
                }
            };
        }
    }
}