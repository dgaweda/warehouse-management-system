using System;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Enums;

namespace DataAccess.Extensions
{
    public static class DepartureExtension
    {
        public static Departure SetState(this Departure departure)
        {
            departure.State = departure.State;
            departure.CloseTime = departure.State == StateType.CLOSED ? DateTime.Now : null;

            return departure;
        }

        public static IQueryable<Departure> FilterByName(this IQueryable<Departure> departures, string name)
        {
            if (string.IsNullOrEmpty(name))
                return departures;

            return departures.Where(departure => departure.Name.Contains(name));
        }

        public static IQueryable<Departure> FilterByOpeningTime(this IQueryable<Departure> departures, DateTime openingTime)
        {
            if (openingTime == default)
                return departures;

            return departures.Where(departure => departure.OpeningTime == openingTime);
        }
    }
}
