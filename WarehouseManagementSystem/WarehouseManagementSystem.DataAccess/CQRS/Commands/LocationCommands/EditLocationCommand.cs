using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class EditLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var locationToEdit = await context.Locations
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            SetLocationProperties(locationToEdit);

            context.Entry(locationToEdit).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return locationToEdit;
        }

        private void SetLocationProperties(Location location)
        {
            if (Parameter.MaxAmount != 0)
                location.MaxAmount = Parameter.MaxAmount;

            if (Parameter.Name != null)
                location.Name = Parameter.Name;
        }
    }
}
