using System;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.ProductPalletLineRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Command.ProductPalletLineCommands
{
    public class DecreaseProductAmountCommand : CommandBase<ProductPalletLine, IProductPalletLineRepository>
    {
        public override async Task Execute(IProductPalletLineRepository productPalletLineRepository)
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
        }
    }
}
