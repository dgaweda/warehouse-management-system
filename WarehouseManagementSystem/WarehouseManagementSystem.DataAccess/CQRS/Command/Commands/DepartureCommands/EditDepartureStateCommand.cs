using System.Threading.Tasks;
using DataAccess.CQRS.Commands;
using DataAccess.CQRS.Extensions;
using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.CQRS.Command.Commands.DepartureCommands
{
    public class EditDepartureStateCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(IRepository<Departure> departureRepository)
        {
            var departureToUpdate = await departureRepository.GetByIdAsync(Parameter.Id);
            departureToUpdate.SetState();
            
            return await departureRepository.UpdateAsync(departureToUpdate);;
        }
    }
}
