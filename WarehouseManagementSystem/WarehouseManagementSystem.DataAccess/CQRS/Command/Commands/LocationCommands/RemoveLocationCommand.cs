using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var location = await context.Locations.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await context.DeleteRecord(Parameter);
            return location;
        }
    }
}
