using System;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;

namespace DataAccess.CQRS.Command.DepartureCommands
{
    public class AddDepartureCommand : CommandBase<Departure, IDepartureRepository>
    {
        public override async Task Execute(IDepartureRepository departureRepository)
        {
            Parameter.OpeningTime = DateTime.Now;
            
            await departureRepository.AddAsync(Parameter);
        }
    }
}
