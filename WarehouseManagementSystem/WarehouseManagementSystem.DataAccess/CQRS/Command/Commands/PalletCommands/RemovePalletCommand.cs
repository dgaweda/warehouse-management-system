using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class RemovePalletCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(IRepository<Pallet> palletRepository)
        {
            var pallet = await palletRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await palletRepository.Delete(Parameter.Id);
            return pallet;
        }
    }
}
