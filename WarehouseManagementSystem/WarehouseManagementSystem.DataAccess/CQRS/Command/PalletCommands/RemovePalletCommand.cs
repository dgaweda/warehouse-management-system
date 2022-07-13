using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.PalletRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class RemovePalletCommand : CommandBase<Pallet, Unit, IPalletRepository>
    {
        public override async Task<Unit> Execute(IPalletRepository palletRepository)
        {
            return await palletRepository.DeleteAsync(Parameter.Id);
        }
    }
}
