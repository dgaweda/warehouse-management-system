using DataAccess.Entities;
using System;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.DepartureRepository;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class AddDepartureCommand : CommandBase<Departure, Departure, IDepartureRepository>
    {
        public override async Task<Departure> Execute(IDepartureRepository departureRepository)
        {
            Parameter.OpeningTime = DateTime.Now;
            
            return await departureRepository.AddAsync(Parameter);
        }
    }
}
