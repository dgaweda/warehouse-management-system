using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Extensions
{
    public static class ProductPalletLineExtension
    {
        public static async Task<List<ProductPalletLine>> GetProductPalletLines(this WMSDatabaseContext context)
        {
            return await context.ProductPalletLines
                .Include(x => x.Product)
                .Include(x => x.Pallet)
                    .ThenInclude(pallet => pallet.Order)
                .Include(x => x.Pallet)
                    .ThenInclude(pallet => pallet.Departure)
                .Include(x => x.Pallet)
                    .ThenInclude(pallet => pallet.Invoice)
                .Include(x => x.Pallet)
                    .ThenInclude(pallet => pallet.User)
                .ToListAsync();
        }

        public static void DecreaseProductAmount(this ProductPalletLine productPalletLine, ProductPalletLine requestProductPalletLine)
        {
            productPalletLine.ProductAmount -= requestProductPalletLine.ProductAmount;
        }

        public static void SetPalletStatus(this Pallet pallet)
        {
            pallet.PalletStatus = PalletStatus.UNFOLDED;
        }

        public static List<ProductPalletLine> FilterByPalletId(this List<ProductPalletLine> palletLines, Guid palletId)
        {
            if (palletId == Guid.Empty)
                return palletLines;

            return palletLines.Where(x => x.PalletId == palletId).ToList();
        }

        public static bool PalletIsEmpty(this WMSDatabaseContext context, ProductPalletLine productPalletLine)
        {
            return !context.ProductPalletLines.Select(x => x.PalletId).Contains(productPalletLine.PalletId);
        } 
    }
}
