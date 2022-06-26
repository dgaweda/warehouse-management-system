using DataAccess.Entities;
using System;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DepartureCommands
{
    public class AddDepartureCommand : CommandBase<Departure, Departure>
    {
        public override async Task<Departure> Execute(IRepository<Departure> departureRepository)
        {
            Parameter.OpeningTime = DateTime.Now;
            
            return await departureRepository.AddAsync(Parameter);
        }
    }
}
