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
    public class RemovePalletCommand : CommandBase<Pallet, IPalletRepository>
    {
        public override async Task Execute(IPalletRepository palletRepository)
        {
            await palletRepository.DeleteAsync(Parameter.Id);
        }
    }
}
