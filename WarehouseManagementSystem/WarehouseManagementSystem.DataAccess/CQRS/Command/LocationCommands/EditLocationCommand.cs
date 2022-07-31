using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.LocationRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Command.LocationCommands
{
    public class EditLocationCommand : CommandBase<Location, ILocationRepository>
    {
        public override async Task Execute(ILocationRepository locationRepository)
        {
            var locationToEdit = await locationRepository.Entity
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            locationToEdit
                .SetMaxAmount(Parameter)
                .SetName(Parameter);
            
            await locationRepository.UpdateAsync(locationToEdit);
        }
    }
}
