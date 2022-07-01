using System.Linq;
using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Extensions;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class SetPalletDestinationCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(IRepository<Pallet> palletRepository)
        {
            var pallet = await palletRepository.GetByIdAsync(Parameter.Id);

            pallet.SetProperties(Parameter);
            pallet.SetStatus();

            await palletRepository.UpdateAsync(pallet);
            
            return await palletRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
        }
    }
}
