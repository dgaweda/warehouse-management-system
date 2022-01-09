using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Commands.ProductsPalletsCommands
{
    public class DecreaseProductAmountCommand : CommandBase<ProductPalletLine, ProductPalletLine>
    {
        public override async Task<ProductPalletLine> Execute(WMSDatabaseContext context)
        {
            var productPalletLine = await context.GetPalletLine(Parameter);

            await productPalletLine.DecreaseProductAmount(Parameter);

            if (productPalletLine.ProductAmount == 0)
                await context.DeleteRecord(productPalletLine);

            if (productPalletLine.ProductAmount < 0)
                throw new ArgumentOutOfRangeException("Amount can't be less than 0.");

            if (PalletIsEmpty(context))
            {
                var pallet = await context.GetById<Pallet>(productPalletLine.PalletId);
                pallet.SetPalletStatus();
            }

            await context.SaveChangesAsync();
            return productPalletLine;
        }

        private bool PalletIsEmpty(WMSDatabaseContext context) => !context.ProductPalletLines.Select(x => x.PalletId).Contains(Parameter.PalletId);
    }
}
