using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class RemoveDepartureCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(WMSDatabaseContext context)
        {
            var departure = await context.Departures.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            context.Remove(departure);
            await context.SaveChangesAsync();
            return departure;
        }
    }
}
