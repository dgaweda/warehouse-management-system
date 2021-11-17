using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class AddLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var nameExists = await context.Locations.AnyAsync(x => x.Name == Parameter.Name);

            if (nameExists)
                throw new ArgumentException("This element already exists in DB.");

            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
