using DataAccess.Entities;
using System;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.DepartureRepository;

namespace DataAccess.CQRS.Commands.DepartureCommands
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
