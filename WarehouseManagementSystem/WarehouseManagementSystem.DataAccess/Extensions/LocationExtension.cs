using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Extensions
{
    public static class LocationExtension
    {
        public static Location SetMaxAmount(this Location locationToEdit, Location locationFromRequest)
        {
            locationToEdit.MaxAmount = locationFromRequest.MaxAmount;

            return locationToEdit;
        }

        public static void SetName(this Location locationToEdit, Location locationFromRequest)
        {
            if (locationFromRequest.Name != null)
                locationToEdit.Name = locationFromRequest.Name;
        }

        public static void SetProductAmount(this Location locationToEdit, Location locationFromRequest)
        {
            locationToEdit.ProductId = locationFromRequest.ProductId;
            locationToEdit.CurrentAmount += locationFromRequest.CurrentAmount;

            if (locationToEdit.CurrentAmount > locationToEdit.MaxAmount)
                throw new Exception("Amount can't be higher than Max Amount of the location.");
        }

        public static IQueryable<Location> FilterByName(this IQueryable<Location> locations, string name)
        {
            if (string.IsNullOrEmpty(name))
                return locations;

            return locations.Where(x => x.Name.Contains(name));
        }
    }
}

