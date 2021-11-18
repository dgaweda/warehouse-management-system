using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var locationToRemove = await context.Locations.FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            if (locationToRemove.CurrentAmount == 0)
                context.Remove(locationToRemove);
            else
                throw new ArgumentException("Location can't be removed. There's still some products left.");

            await context.SaveChangesAsync();
            return locationToRemove;
        }
    }
}
