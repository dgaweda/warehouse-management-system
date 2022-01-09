using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Helpers
{
    public static class ProductPalletLineHelper
    {
        public static async Task<Entities.ProductPalletLine> GetPalletLine(this WMSDatabaseContext context, ProductPalletLine requestProductPalletLine)
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
                .FirstOrDefaultAsync(x => x.PalletId == requestProductPalletLine.PalletId && x.ProductId == requestProductPalletLine.ProductId);
        }

        public static async Task DecreaseProductAmount(this ProductPalletLine productPalletLine, ProductPalletLine requestProductPalletLine)
        {
            productPalletLine.ProductAmount -= requestProductPalletLine.ProductAmount;
        }

        public static void SetPalletStatus(this Pallet pallet)
        {
            pallet.PalletStatus = PalletEnum.Status.UNFOLDED;
        }
    }
}
