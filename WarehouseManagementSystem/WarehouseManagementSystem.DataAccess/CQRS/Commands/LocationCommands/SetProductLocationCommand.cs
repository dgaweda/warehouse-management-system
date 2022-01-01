using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.ProductCommands
{
    public class SetProductLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var location = await GetLocation(context);

            location = SetProperties(location);

            context.Entry(location).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return location;
        }

        private async Task<Location> GetLocation(WMSDatabaseContext context) => await context.Locations.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == Parameter.Id);

        private Location SetProperties(Location location)
        {
            if (Parameter.ProductId != 0)
            {
                location.ProductId = Parameter.ProductId;
                location.CurrentAmount += Parameter.CurrentAmount;
                if (location.CurrentAmount > location.MaxAmount)
                    throw new Exception("Amount can't be higher than Max Amount of the location.");
            }

            return location;
        }
    }
}
