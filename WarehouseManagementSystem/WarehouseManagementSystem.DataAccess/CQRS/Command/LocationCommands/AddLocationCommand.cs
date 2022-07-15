using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.LocationRepository;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class AddLocationCommand : CommandBase<Location, ILocationRepository>
    {
        public override async Task Execute(ILocationRepository locationRepository)
        {
            await locationRepository.AddAsync(Parameter);;
        }
    }
}
