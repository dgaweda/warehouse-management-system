using DataAccess.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Extensions;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.ProductsPalletsCommands
{
    public class DecreaseProductAmountCommand : CommandBase<ProductPalletLine, ProductPalletLine>
    {
        public override async Task<ProductPalletLine> Execute(IRepository<ProductPalletLine> productPalletLineRepository)
        {
            var dbContext = productPalletLineRepository.GetDbContext();
            var productPalletLine = await productPalletLineRepository.Entity
                .FirstOrDefaultAsync(x => x.PalletId == Parameter.PalletId && x.ProductId == Parameter.ProductId);

            var pallet = await dbContext.Set<Pallet>()
                .FirstOrDefaultAsync(@pallet => @pallet.Id == productPalletLine.PalletId);
            

            productPalletLine.DecreaseProductAmount(Parameter);

            if (productPalletLine.ProductAmount == default)
                await productPalletLineRepository.DeleteAsync(productPalletLine.Id);

            if (productPalletLine.ProductAmount < 0)
                throw new ArgumentOutOfRangeException("Amount can't be less than 0.");

            if (dbContext.PalletIsEmpty(productPalletLine))
            {
                pallet.SetPalletStatus();
            }

            await dbContext.SaveChangesAsync();
            return productPalletLine;
        }
    }
}
