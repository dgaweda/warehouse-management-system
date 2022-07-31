using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.LocationRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Command.LocationCommands
{
    public class SetProductLocationCommand : CommandBase<Location, ILocationRepository>
    {
        public override async Task Execute(ILocationRepository locationRepository)
        {
            var location = await locationRepository.Entity
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id); ;

            location.SetProductAmount(Parameter);
            await locationRepository.UpdateAsync(location);
        }
    }
}
