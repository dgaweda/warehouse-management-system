using DataAccess.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.ProductsPalletsCommands
{
    public class DecreaseProductAmountCommand : CommandBase<ProductPalletLine, ProductPalletLine>
    {
        public override async Task<ProductPalletLine> Execute(WMSDatabaseContext context)
        {
            var productPalletLines = await context.GetProductPalletLines();
            var productPalletLine = productPalletLines
                .FirstOrDefault(x => x.PalletId == Parameter.PalletId && x.ProductId == Parameter.ProductId);

            await productPalletLine.DecreaseProductAmount(Parameter);

            if (productPalletLine.ProductAmount == default)
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
