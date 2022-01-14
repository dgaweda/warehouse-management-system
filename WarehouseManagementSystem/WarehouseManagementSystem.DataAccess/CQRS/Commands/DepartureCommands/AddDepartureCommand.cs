using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class AddDepartureCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(WMSDatabaseContext context)
        {
            Parameter.OpeningTime = DateTime.Now;

            await context.AddRecord(Parameter);
            return Parameter;
        }
    }
}
