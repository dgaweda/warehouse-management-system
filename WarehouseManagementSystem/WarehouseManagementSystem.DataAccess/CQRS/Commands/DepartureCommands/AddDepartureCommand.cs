using DataAccess.Entities;
using System;
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
