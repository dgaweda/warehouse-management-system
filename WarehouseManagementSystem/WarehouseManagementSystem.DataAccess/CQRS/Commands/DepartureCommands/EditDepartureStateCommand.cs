using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class EditDepartureStateCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(WMSDatabaseContext context)
        {
            var departureToUpdate = await context.Departures.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            departureToUpdate.State = Parameter.State;

            if (Parameter.State == StateType.CLOSED)
                departureToUpdate.CloseTime = DateTime.Now;
            else
                departureToUpdate.CloseTime = null;

            context.Entry(departureToUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return departureToUpdate;
        }
    }
}
