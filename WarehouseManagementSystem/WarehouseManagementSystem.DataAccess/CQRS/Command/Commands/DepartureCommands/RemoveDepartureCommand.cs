using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class RemoveDepartureCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(IRepository<Departure> departureRepository)
        {
            var departure = await departureRepository.GetById(Parameter.Id);
            await departureRepository.Delete(Parameter.Id);
            return departure;
        }
    }
}
