using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class EditLocationCurrentAmountCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var locationToEdit = await context.Locations.FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            await context.UpdateRecord(locationToEdit);
            return locationToEdit;
        }

        
    }
}
