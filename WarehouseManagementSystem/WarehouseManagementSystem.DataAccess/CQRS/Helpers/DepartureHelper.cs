using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.CQRS.Helpers
{
    public static class DepartureHelper
    {
        public async static Task<Departure> SetState(this Departure departure)
        {
            departure.State = departure.State;
            departure.CloseTime = departure.State == StateType.CLOSED ? DateTime.Now : null;

            return departure;
        }

        public static List<Departure> FilterByName(this List<Departure> departures, string Name)
        {
            if (string.IsNullOrEmpty(Name))
                return departures;

            return departures.Where(departure => departure.Name.Contains(Name)).ToList();
        }

        public static List<Departure> FilterByOpeningTime(this List<Departure> departures, DateTime OpeningTime)
        {
            if (OpeningTime == default)
                return departures;

            return departures.Where(departure => departure.OpeningTime == OpeningTime).ToList();
        }
    }
}
