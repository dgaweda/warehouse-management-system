using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Extensions;
using DataAccess.Repository;
using DataAccess.Repository.LocationRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class EditLocationCommand : CommandBase<Location, Location, ILocationRepository>
    {
        public override async Task<Location> Execute(ILocationRepository locationRepository)
        {
            var locationToEdit = await locationRepository.Entity
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            locationToEdit
                .SetMaxAmount(Parameter)
                .SetName(Parameter);
            
            return await locationRepository.UpdateAsync(locationToEdit);
        }
    }
}
