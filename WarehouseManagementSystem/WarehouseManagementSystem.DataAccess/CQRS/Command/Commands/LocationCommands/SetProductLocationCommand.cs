using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Extensions;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.ProductCommands
{
    public class SetProductLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(IRepository<Location> locationRepository)
        {
            var location = await locationRepository.Entity
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id); ;

            location.SetProductAmount(Parameter);
            return await locationRepository.UpdateAsync(location);
        }


    }
}
