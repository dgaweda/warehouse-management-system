using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.ProductsPalletsCommands
{
    public class SetProductAmountCommand : CommandBase<ProductPalletLine, ProductPalletLine>
    {
        public override async Task<ProductPalletLine> Execute(WMSDatabaseContext context)
        {   
            var palletLine = await DecreaseProductAmount(context);
            
            if (await PalletIsEmpty(context))
                palletLine.Pallet.PalletStatus = Status.UNFOLDED;
            
            await context.SaveChangesAsync();
            return palletLine;
        }

        
        private async Task<ProductPalletLine> DecreaseProductAmount(WMSDatabaseContext context)
        {
            var palletLine = await GetPalletLine(context);

            palletLine.ProductAmount -= Parameter.ProductAmount;

            if (ProductAmountIsZero(palletLine))
                context.ProductPalletLines.Remove(palletLine);

            if (ProductAmountIsBelowZero(palletLine))
                throw new ArgumentException("Amount can't be lower than 0.");

            return palletLine;
        }

        private async Task<ProductPalletLine> GetPalletLine(WMSDatabaseContext context)
        {
            return await context.ProductPalletLines
                .Include(x => x.Product)
                .Include(x => x.Pallet)
                    .ThenInclude(order => order.Order)
                .Include(x => x.Pallet)
                    .ThenInclude(departure => departure.Departure)
                .Include(x => x.Pallet)
                    .ThenInclude(invoice => invoice.Invoice)
                .Include(x => x.Pallet)
                    .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.PalletId == Parameter.PalletId && x.ProductId == Parameter.ProductId);
        }

        private bool ProductAmountIsZero(ProductPalletLine palletLine) => palletLine.ProductAmount == 0;
        private async Task<bool> PalletIsEmpty(WMSDatabaseContext context) => await context.ProductPalletLines.Select(x => x.PalletId).ContainsAsync(Parameter.PalletId);
        private bool ProductAmountIsBelowZero(ProductPalletLine palletLine) => palletLine.ProductAmount < 0;
    }
}
