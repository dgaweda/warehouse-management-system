﻿using System;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.ProductPalletLineRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Command.ProductPalletLineCommands
{
    public class DecreaseProductAmountCommand : CommandBase<PalletRow, IProductPalletLineRepository>
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

            if (await productPalletLineRepository.PalletIsEmpty(productPalletLine.PalletId))
            {
                pallet.SetPalletStatus();
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
