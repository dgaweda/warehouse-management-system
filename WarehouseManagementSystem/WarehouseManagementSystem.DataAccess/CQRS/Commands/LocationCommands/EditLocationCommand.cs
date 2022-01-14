using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class EditLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var locationToEdit = await context.Locations
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            locationToEdit
                .SetMaxAmount(Parameter)
                .SetName(Parameter);

            await context.UpdateRecord(locationToEdit);
            return locationToEdit;
        }
    }
}
