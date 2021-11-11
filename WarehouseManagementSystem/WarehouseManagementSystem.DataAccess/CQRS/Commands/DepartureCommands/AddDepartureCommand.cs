using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class AddDepartureCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(WMSDatabaseContext context)
        {
            if (Parameter == null)
                throw new ArgumentNullException();

            Parameter.OpeningTime = DateTime.Now;
            await context.Departures.AddAsync(Parameter);
            await context.SaveChangesAsync();

            var addedRecord = await context.Departures.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            return addedRecord;
        }
    }
}
