using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Command.LocationCommands
{
    public class EditLocationCurrentAmountCommand : CommandBase<Location, ILocationRepository>
    {
        public override async Task Execute(ILocationRepository locationRepository)
        {
            var locationToEdit = await locationRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            
            await locationRepository.UpdateAsync(locationToEdit);
        }
    }
}
