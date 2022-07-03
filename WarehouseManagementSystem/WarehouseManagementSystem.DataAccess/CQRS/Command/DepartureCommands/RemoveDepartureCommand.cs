using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.DepartureRepository;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class RemoveDepartureCommand : CommandBase<Departure, Departure, IDepartureRepository>
    {
        public override async Task<Departure> Execute(IDepartureRepository departureRepository)
        {
            var departure = await departureRepository.GetByIdAsync(Parameter.Id);
            await departureRepository.DeleteAsync(Parameter.Id);
            return departure;
        }
    }
}
