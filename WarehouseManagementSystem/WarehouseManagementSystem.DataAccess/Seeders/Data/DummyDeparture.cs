using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seed
{
    public class DummyDeparture
    {
        public static List<Departure> GetDummyDepartures()
        {
            var sampleOpeningData1 = new DateTime(2022, 5, 3);
            var sampleOpeningData2 = new DateTime(2021, 3, 1);
            var sampleClosingData = new DateTime(2021, 3, 2);

            return new List<Departure>()
            {
                new Departure()
                {
                    Name = "Sample Opened Departure 1",
                    State = StateType.OPEN,
                    OpeningTime = sampleOpeningData1
                },

                new Departure()
                {
                    Name = "Sample Closed Departure 2",
                    State = StateType.CLOSED,
                    OpeningTime = sampleOpeningData2,
                    CloseTime = sampleClosingData
                },
            };
        }
    }
}