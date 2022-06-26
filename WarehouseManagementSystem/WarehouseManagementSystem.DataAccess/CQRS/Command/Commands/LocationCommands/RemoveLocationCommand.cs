using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(IRepository<Location> locationRepository)
        {
            var location = await locationRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await locationRepository.DeleteAsync(Parameter.Id);
            return location;
        }
    }
}
