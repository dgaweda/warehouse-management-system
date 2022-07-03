using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.LocationRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class EditLocationCurrentAmountCommand : CommandBase<Location, Location, ILocationRepository>
    {
        public override async Task<Location> Execute(ILocationRepository locationRepository)
        {
            var locationToEdit = await locationRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            
            return await locationRepository.UpdateAsync(locationToEdit);
        }

        
    }
}
