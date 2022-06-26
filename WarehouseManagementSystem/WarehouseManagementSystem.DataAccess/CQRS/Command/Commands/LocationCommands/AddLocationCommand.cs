using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class AddLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(IRepository<Location> locationRepository)
        {
            await locationRepository.AddAsync(Parameter);
            return Parameter;
        }
    }
}
