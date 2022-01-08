using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class SetPalletDestinationCommand : CommandBase<Pallet, Pallet>
    {
        public IPalletPropertiesSetter Setter { get; set; }
        public SetPalletDestinationCommand()
        {
            Setter = new PalletPropertiesSetter();
        }

        public override async Task<Pallet> Execute(WMSDatabaseContext context)
        {
            var pallet = await GetPallet(context);

            Setter.SetPalletProperties(pallet, Parameter);

            context.Entry(pallet).State = EntityState.Modified;
            await context.SaveChangesAsync();

            pallet = await GetPallet(context);

            Setter.SetPalletStatus(pallet);
            await context.SaveChangesAsync();

            return pallet;
        }

        private async Task<Pallet> GetPallet(WMSDatabaseContext context)
        {
            return await context.Pallets
                .Include(x => x.Departure)
                .Include(x => x.Order)
                .Include(x => x.Invoice.Delivery)
                .Include(x => x.User)
                .Include(x => x.User.Role)
                .Include(x => x.User.Seniority)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);
        }
    }
}
