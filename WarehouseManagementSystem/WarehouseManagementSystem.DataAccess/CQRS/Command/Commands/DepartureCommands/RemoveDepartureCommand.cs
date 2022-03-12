using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class RemoveDepartureCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(WMSDatabaseContext context)
        {
            await context.DeleteRecord(Parameter);
            var departure = await context.GetById<Departure>(Parameter.Id);
            return departure;
        }
    }
}
