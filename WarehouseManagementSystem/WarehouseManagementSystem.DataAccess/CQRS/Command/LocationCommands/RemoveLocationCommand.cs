using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.LocationRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand : CommandBase<Location, Unit, ILocationRepository>
    {
        public override async Task<Unit> Execute(ILocationRepository locationRepository)
        {
            return await locationRepository.DeleteAsync(Parameter.Id);
        }
    }
}
