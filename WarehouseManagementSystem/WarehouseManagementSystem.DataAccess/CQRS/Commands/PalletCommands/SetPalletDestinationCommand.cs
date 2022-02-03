using System.Linq;
using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class SetPalletDestinationCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(WMSDatabaseContext context)
        {
            var pallet = await context.GetById<Pallet>(Parameter.Id);

            pallet.SetProperties(Parameter);
            pallet.SetStatus();

            await context.UpdateRecord(pallet);

            var pallets = await context.GetPallets();
            return pallets.FirstOrDefault(x => x.Id == Parameter.Id);
        }
    }
}
