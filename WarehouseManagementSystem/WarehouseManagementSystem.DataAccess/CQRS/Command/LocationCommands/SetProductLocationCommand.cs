using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Extensions;
using DataAccess.Repository;
using DataAccess.Repository.LocationRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.ProductCommands
{
    public class SetProductLocationCommand : CommandBase<Location, Location, ILocationRepository>
    {
        public override async Task<Location> Execute(ILocationRepository locationRepository)
        {
            var location = await locationRepository.Entity
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id); ;

            location.SetProductAmount(Parameter);
            return await locationRepository.UpdateAsync(location);
        }


    }
}
