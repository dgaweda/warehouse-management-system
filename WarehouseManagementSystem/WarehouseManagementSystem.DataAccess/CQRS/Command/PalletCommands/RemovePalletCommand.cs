using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.PalletRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class RemovePalletCommand : CommandBase<Pallet, Pallet, IPalletRepository>
    {
        public override async Task<Pallet> Execute(IPalletRepository palletRepository)
        {
            var pallet = await palletRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await palletRepository.DeleteAsync(Parameter.Id);
            return pallet;
        }
    }
}
