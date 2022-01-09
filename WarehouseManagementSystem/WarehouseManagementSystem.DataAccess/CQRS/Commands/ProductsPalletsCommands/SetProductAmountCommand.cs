﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.ProductsPalletsCommands
{
    public class SetProductAmountCommand : CommandBase<PalletLine, PalletLine>
    {
        public override async Task<PalletLine> Execute(WMSDatabaseContext context)
        {   
            var palletLine = await SetProductAmount(context);
            
            if (await PalletIsEmpty(context))
                palletLine.Pallet.PalletStatus = Status.UNFOLDED;
            
            await context.SaveChangesAsync();
            return palletLine;
        }

        
        private async Task<PalletLine> SetProductAmount(WMSDatabaseContext context)
        {
            var palletLine = await GetPalletLine(context);

            palletLine.ProductAmount -= Parameter.ProductAmount;

            if (ProductAmountIsZero(palletLine))
                context.PalletLines.Remove(palletLine);

            if (ProductAmountIsBelowZero(palletLine))
                throw new ArgumentException("Amount can't be lower than 0.");

            return palletLine;
        }

        private async Task<PalletLine> GetPalletLine(WMSDatabaseContext context)
        {
            return await context.PalletLines
                .Include(x => x.Product)
                .Include(x => x.Pallet)
                    .ThenInclude(order => order.Order)
                .Include(x => x.Pallet)
                    .ThenInclude(departure => departure.Departure)
                .Include(x => x.Pallet)
                    .ThenInclude(invoice => invoice.Invoice)
                .Include(x => x.Pallet)
                    .ThenInclude(employee => employee.Employee)
                .FirstOrDefaultAsync(x => x.PalletId == Parameter.PalletId && x.ProductId == Parameter.ProductId);
        }

        private bool ProductAmountIsZero(PalletLine palletLine) => palletLine.ProductAmount == 0;
        private async Task<bool> PalletIsEmpty(WMSDatabaseContext context) => await context.PalletLines.Select(x => x.PalletId).ContainsAsync(Parameter.PalletId);
        private bool ProductAmountIsBelowZero(PalletLine palletLine) => palletLine.ProductAmount < 0;
    }
}