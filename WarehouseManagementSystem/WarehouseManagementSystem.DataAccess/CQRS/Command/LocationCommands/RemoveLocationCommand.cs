using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.LocationRepository;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand : CommandBase<Location, ILocationRepository>
    {
        public override async Task Execute(ILocationRepository locationRepository)
        {
            await locationRepository.DeleteAsync(Parameter.Id);
        }
    }
}
