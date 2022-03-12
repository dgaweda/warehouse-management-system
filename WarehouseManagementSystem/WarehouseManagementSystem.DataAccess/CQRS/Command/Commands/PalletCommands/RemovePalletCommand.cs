using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class RemovePalletCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(WMSDatabaseContext context)
        {
            var pallet = await context.Pallets.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await context.DeleteRecord(Parameter);
            return pallet;
        }
    }
}
