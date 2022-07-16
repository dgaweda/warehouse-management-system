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
        public static void DecreaseProductAmount(this ProductPalletLine productPalletLine, ProductPalletLine requestProductPalletLine)
        {
            productPalletLine.ProductAmount -= requestProductPalletLine.ProductAmount;
        }

        public static void SetPalletStatus(this Pallet pallet)
        {
            pallet.PalletStatus = PalletStatus.UNFOLDED;
        }

        public static IQueryable<ProductPalletLine> FilterByPalletId(this IQueryable<ProductPalletLine> palletLines, Guid palletId)
        {
            if (palletId == Guid.Empty)
                return palletLines;

            return palletLines.Where(x => x.PalletId == palletId);
        }
    }
}
