using System.Reflection;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class SetPalletDestinationCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(WMSDatabaseContext context)
        {
            var pallet = await context.GetPalletBy(Parameter.Id);

            pallet.SetProperties(Parameter);
            await context.UpdateRecord(pallet);

            pallet = await context.GetPalletBy(Parameter.Id);
            pallet.SetStatus();
            await context.SaveChangesAsync();

            return pallet;
        }
    }
}
