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
        public static void DecreaseProductAmount(this PalletRow palletRow, PalletRow requestPalletRow)
        {
            palletRow.ProductAmount -= requestPalletRow.ProductAmount;
        }

        public static void SetPalletStatus(this Pallet pallet)
        {
            pallet.PalletStatus = PalletStatus.UNFOLDED;
        }

        public static IQueryable<PalletRow> FilterByPalletId(this IQueryable<PalletRow> palletLines, Guid palletId)
        {
            if (palletId == Guid.Empty)
                return palletLines;

            return palletLines.Where(x => x.PalletId == palletId);
        }
    }
}
