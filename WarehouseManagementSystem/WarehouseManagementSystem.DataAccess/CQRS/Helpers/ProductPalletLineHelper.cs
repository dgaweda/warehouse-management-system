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

        public static async Task DecreaseProductAmount(this ProductPalletLine productPalletLine, ProductPalletLine requestProductPalletLine)
        {
            productPalletLine.ProductAmount -= requestProductPalletLine.ProductAmount;
        }

        public static void SetPalletStatus(this Pallet pallet)
        {
            pallet.PalletStatus = PalletEnum.Status.UNFOLDED;
        }

        public static List<ProductPalletLine> FilterByPalletId(this List<ProductPalletLine> palletLines, int palletId)
        {
            if (palletId == default)
                return palletLines;

            return palletLines.Where(x => x.PalletId == palletId).ToList();
        }
    }
}
