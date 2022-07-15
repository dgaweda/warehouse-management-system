using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.DepartureRepository;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class RemoveDepartureCommand : CommandBase<Departure, IDepartureRepository>
    {
        public override async Task Execute(IDepartureRepository departureRepository)
        {
            await departureRepository.DeleteAsync(Parameter.Id);
        }
    }
}
