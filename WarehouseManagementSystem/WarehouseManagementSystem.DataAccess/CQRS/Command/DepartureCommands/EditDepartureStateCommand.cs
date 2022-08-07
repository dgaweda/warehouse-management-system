using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.DepartureRepository;

namespace DataAccess.CQRS.Command.DepartureCommands
{
    public class EditDepartureStateCommand : CommandBase<Departure, IDepartureRepository>
    {
        public override async Task Execute(IDepartureRepository departureRepository)
        {
            var departureToUpdate = await departureRepository.GetByIdAsync(Parameter.Id);
            departureToUpdate.SetState();
            
            await departureRepository.UpdateAsync(departureToUpdate);;
        }
    }
}
