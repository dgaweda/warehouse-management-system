﻿using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class RemoveDepartureCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(WMSDatabaseContext context)
        {
            var deletedDeparture = await context.DeleteRecord(Parameter);
            return deletedDeparture;
        }
    }
}
