using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class EditLocationCurrentAmountCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var locationToEdit = await context.Locations.FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            locationToEdit.CurrentAmount = SetCurrentAmount(locationToEdit);
            context.Entry(locationToEdit).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return locationToEdit;
        }

        private int SetCurrentAmount(Location location)
        {
            if (Parameter.CurrentAmount < 0)
                return 0;
            else if (Parameter.CurrentAmount > location.MaxAmount)
                throw new ArgumentException("Current amount can't be higher than Max Amount.");
            else
                return Parameter.CurrentAmount;
        }
    }
}
