using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.DepartureRepository;
using MediatR;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class RemoveDepartureCommand : CommandBase<Departure, Unit, IDepartureRepository>
    {
        public override async Task<Unit> Execute(IDepartureRepository departureRepository)
        {
            return await departureRepository.DeleteAsync(Parameter.Id);
        }
    }
}
