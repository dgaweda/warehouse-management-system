using System;
using System.Collections.Generic;
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
    }
}