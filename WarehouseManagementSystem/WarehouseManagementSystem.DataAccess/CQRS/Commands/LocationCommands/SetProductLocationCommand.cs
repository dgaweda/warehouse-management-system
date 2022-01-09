using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.ProductCommands
{
    public class SetProductLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var location = await context.Locations
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id); ;

            location.SetProductAmount(Parameter);

            await context.UpdateRecord(location);
            return location;
        }


    }
}
