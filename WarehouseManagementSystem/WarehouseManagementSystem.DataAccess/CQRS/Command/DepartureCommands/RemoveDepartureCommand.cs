﻿using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;

namespace DataAccess.CQRS.Command.DepartureCommands
{
    public class RemoveDepartureCommand : CommandBase<Departure, IDepartureRepository>
    {
        public override async Task Execute(IDepartureRepository departureRepository)
        {
            await departureRepository.DeleteAsync(Parameter.Id);
        }
    }
}
