using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class RemovePalletCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(WMSDatabaseContext context)
        {
            var pallet = await context.Pallets
                .Include(x => x.Departure)
                .Include(x => x.Order)
                .Include(x => x.Invoice.Delivery)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            context.Remove(pallet);
            await context.SaveChangesAsync();
            return pallet;
        }
    }
}
