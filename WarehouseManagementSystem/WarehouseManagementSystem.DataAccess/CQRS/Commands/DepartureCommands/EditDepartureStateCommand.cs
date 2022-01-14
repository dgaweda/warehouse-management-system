using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class EditDepartureStateCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(WMSDatabaseContext context)
        {
            var departureToUpdate = await context.GetById<Departure>(Parameter.Id);
            await departureToUpdate.SetState();

            await context.UpdateRecord(departureToUpdate);
            return departureToUpdate;
        }
    }
}
