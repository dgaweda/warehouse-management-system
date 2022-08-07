using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;

namespace DataAccess.CQRS.Command.LocationCommands
{
    public class AddLocationCommand : CommandBase<Location, ILocationRepository>
    {
        public override async Task Execute(ILocationRepository locationRepository)
        {
            await locationRepository.AddAsync(Parameter);;
        }
    }
}
