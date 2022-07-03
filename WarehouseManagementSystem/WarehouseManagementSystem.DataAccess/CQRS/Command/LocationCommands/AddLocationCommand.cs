using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.LocationRepository;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class AddLocationCommand : CommandBase<Location, Location, ILocationRepository>
    {
        public override async Task<Location> Execute(ILocationRepository locationRepository)
        {
            return await locationRepository.AddAsync(Parameter);;
        }
    }
}
